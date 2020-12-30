using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace QuickPuzzle.DomainObject
{
    [DependsOn(
        typeof(DomainObjectDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class DomainObjectApplicationContractsModule : AbpModule
    {

    }
}
