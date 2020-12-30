using Volo.Abp.Reflection;

namespace QuickPuzzle.ProjectManagement.Permissions
{
    public class ProjectManagementPermissions
    {
        public const string GroupName = "ProjectManagement";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProjectManagementPermissions));
        }
    }
}