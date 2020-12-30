using QuickPuzzle.DomainObject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QuickPuzzle.DomainObject.Permissions
{
    public class DomainObjectPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DomainObjectPermissions.GroupName, L("Permission:DomainObject"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DomainObjectResource>(name);
        }
    }
}