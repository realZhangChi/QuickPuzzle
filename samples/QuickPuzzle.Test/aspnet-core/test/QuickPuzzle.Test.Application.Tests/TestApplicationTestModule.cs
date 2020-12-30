using Volo.Abp.Modularity;

namespace QuickPuzzle.Test
{
    [DependsOn(
        typeof(TestApplicationModule),
        typeof(TestDomainTestModule)
        )]
    public class TestApplicationTestModule : AbpModule
    {

    }
}