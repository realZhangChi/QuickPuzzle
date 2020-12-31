using QuickPuzzle.ProjectManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QuickPuzzle.ProjectManagement.Permissions
{
    public class ProjectManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var projectManagementGroup = context.AddGroup(ProjectManagementPermissions.GroupName, L("Permission:ProjectManagement"));
            var projectPermission = projectManagementGroup.AddPermission(ProjectManagementPermissions.Project.Default);
            projectPermission.AddChild(ProjectManagementPermissions.Project.Get);
            projectPermission.AddChild(ProjectManagementPermissions.Project.Create);
            projectPermission.AddChild(ProjectManagementPermissions.Project.Update);
            projectPermission.AddChild(ProjectManagementPermissions.Project.Delete);

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProjectManagementResource>(name);
        }
    }
}