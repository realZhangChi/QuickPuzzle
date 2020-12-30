using System.Threading.Tasks;
using QuickPuzzle.ProjectManagement.Localization;
using Volo.Abp.UI.Navigation;

namespace QuickPuzzle.Blazor.Host
{
    public class QuickPuzzleHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<ProjectManagementResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "QuickPuzzle.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
