using System.Reflection;
using System.Reflection.Emit;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;

namespace QuickPuzzle.EntityFactory
{
    public class DefaultEntityFactory : ISingletonDependency
    {
        private readonly IServiceProvider _serviceProvider;

        private static ConcurrentDictionary<string, Type> Entities;

        public DefaultEntityFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Entities = new ConcurrentDictionary<string, Type>();
        }

        public Type GetEntity(string name)
        {
            if (!Entities.ContainsKey(name))
            {
                lock (this)
                {
                    if (!Entities.ContainsKey(name))
                    {
                        var typeBuilder = GetTypeBuilder();
                        var construct = typeBuilder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
                        typeBuilder.SetParent(typeof(Entity<Guid>));
                        // CreateProperty(typeBuilder, "Id", typeof(Guid));
                        var type = typeBuilder.CreateType();
                        Entities[name] = type;
                    }
                }
            }
            return Entities[name];
        }

        private static TypeBuilder GetTypeBuilder()
        {
            var typeSignature = "MyDynamicType";
            var an = new AssemblyName(typeSignature);
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            var tb = moduleBuilder.DefineType(typeSignature,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);
            return tb;
        }

        private static void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
        {
            FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

            PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
            MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            ILGenerator getIl = getPropMthdBldr.GetILGenerator();

            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            MethodBuilder setPropMthdBldr =
                tb.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });

            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
        }
    }
}
