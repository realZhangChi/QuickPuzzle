using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace QuickPuzzle.DomainObject
{
    [DependsOn(
        typeof(DomainObjectHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DomainObjectConsoleApiClientModule : AbpModule
    {
        
    }
}
