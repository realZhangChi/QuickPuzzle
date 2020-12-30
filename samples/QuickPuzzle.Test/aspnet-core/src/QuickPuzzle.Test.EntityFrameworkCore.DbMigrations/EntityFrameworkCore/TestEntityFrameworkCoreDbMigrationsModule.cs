using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace QuickPuzzle.Test.EntityFrameworkCore
{
    [DependsOn(
        typeof(TestEntityFrameworkCoreModule)
        )]
    public class TestEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TestMigrationsDbContext>();
        }
    }
}
