using Microsoft.Extensions.DependencyInjection;
using QuickPuzzle.DomainObject.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace QuickPuzzle.DomainObject.Blazor
{
    [DependsOn(
        typeof(DomainObjectHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class DomainObjectBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<DomainObjectBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<DomainObjectBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DomainObjectMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(DomainObjectBlazorModule).Assembly);
            });
        }
    }
}