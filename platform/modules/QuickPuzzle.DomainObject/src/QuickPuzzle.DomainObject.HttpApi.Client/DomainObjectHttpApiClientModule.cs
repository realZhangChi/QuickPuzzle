using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace QuickPuzzle.DomainObject
{
    [DependsOn(
        typeof(DomainObjectApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class DomainObjectHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "DomainObject";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(DomainObjectApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
