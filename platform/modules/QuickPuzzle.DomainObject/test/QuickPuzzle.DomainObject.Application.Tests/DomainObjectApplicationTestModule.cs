using Volo.Abp.Modularity;

namespace QuickPuzzle.DomainObject
{
    [DependsOn(
        typeof(DomainObjectApplicationModule),
        typeof(DomainObjectDomainTestModule)
        )]
    public class DomainObjectApplicationTestModule : AbpModule
    {

    }
}
