using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using QuickPuzzle.ProjectManagement.Localization;
using QuickPuzzle.ProjectManagement.Permissions;

namespace QuickPuzzle.ProjectManagement.Blazor.Menus
{
    public class ProjectManagementMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            //Add main menu items.
            if (context.Menu.Name != StandardMenus.Main)
            {
                return;
            }


            if (!(await context.IsGrantedAsync(ProjectManagementPermissions.Project.Default)))
            {
                return;
            }

            var l = context.GetLocalizer<ProjectManagementResource>();

            var projectManagementMenuItem = new ApplicationMenuItem(
                ProjectManagementMenus.GroupName,
                l[$"Menu:{ProjectManagementMenus.GroupName}"],
                icon: "fa fa-users");

            projectManagementMenuItem.AddItem(
                new ApplicationMenuItem(
                    ProjectManagementMenus.Projects,
                    l[$"Menu:{ProjectManagementMenus.Projects}"],
                    "/project-management/project",
                    icon: "fa fa-users"
                )
            );

            context.Menu.AddItem(projectManagementMenuItem);
        }
    }
}