using QuickPuzzle.Test.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QuickPuzzle.Test
{
    [DependsOn(
        typeof(TestEntityFrameworkCoreTestModule)
        )]
    public class TestDomainTestModule : AbpModule
    {

    }
}