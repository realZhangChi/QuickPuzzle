using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace QuickPuzzle.DomainObject.MongoDB
{
    [DependsOn(
        typeof(DomainObjectDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class DomainObjectMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<DomainObjectMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
