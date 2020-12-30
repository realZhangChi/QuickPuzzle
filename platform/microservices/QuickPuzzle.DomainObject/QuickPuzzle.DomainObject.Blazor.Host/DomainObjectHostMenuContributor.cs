using System.Threading.Tasks;
using QuickPuzzle.DomainObject.Localization;
using Volo.Abp.UI.Navigation;

namespace QuickPuzzle.DomainObject.Blazor.Host
{
    public class DomainObjectHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<DomainObjectResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "DomainObject.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
