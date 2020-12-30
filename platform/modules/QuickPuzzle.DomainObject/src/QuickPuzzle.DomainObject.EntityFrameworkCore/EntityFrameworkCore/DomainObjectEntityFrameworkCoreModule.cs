using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QuickPuzzle.DomainObject.EntityFrameworkCore
{
    [DependsOn(
        typeof(DomainObjectDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class DomainObjectEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DomainObjectDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}