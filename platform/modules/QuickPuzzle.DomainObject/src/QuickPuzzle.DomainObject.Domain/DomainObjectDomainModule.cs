using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace QuickPuzzle.DomainObject
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DomainObjectDomainSharedModule)
    )]
    public class DomainObjectDomainModule : AbpModule
    {

    }
}
