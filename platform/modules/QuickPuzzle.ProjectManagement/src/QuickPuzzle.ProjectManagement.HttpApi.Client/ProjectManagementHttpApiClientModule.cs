using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace QuickPuzzle.ProjectManagement
{
    [DependsOn(
        typeof(ProjectManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ProjectManagementHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "ProjectManagement";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ProjectManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
