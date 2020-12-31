using Volo.Abp.Reflection;

namespace QuickPuzzle.ProjectManagement.Permissions
{
    public class ProjectManagementPermissions
    {
        public const string GroupName = "ProjectManagement";

        public static class Project
        {
            public const string Default = GroupName + ".Project";
            public const string Get = Default + ".Get";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";

        }
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProjectManagementPermissions));
        }
    }
}