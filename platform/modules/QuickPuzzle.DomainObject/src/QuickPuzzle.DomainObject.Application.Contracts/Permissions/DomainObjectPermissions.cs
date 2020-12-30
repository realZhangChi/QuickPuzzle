using Volo.Abp.Reflection;

namespace QuickPuzzle.DomainObject.Permissions
{
    public class DomainObjectPermissions
    {
        public const string GroupName = "DomainObject";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DomainObjectPermissions));
        }
    }
}