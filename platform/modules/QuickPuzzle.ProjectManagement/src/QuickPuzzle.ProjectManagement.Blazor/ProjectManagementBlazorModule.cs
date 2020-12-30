using Microsoft.Extensions.DependencyInjection;
using QuickPuzzle.ProjectManagement.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace QuickPuzzle.ProjectManagement.Blazor
{
    [DependsOn(
        typeof(ProjectManagementHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ProjectManagementBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ProjectManagementBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ProjectManagementBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new ProjectManagementMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(ProjectManagementBlazorModule).Assembly);
            });
        }
    }
}