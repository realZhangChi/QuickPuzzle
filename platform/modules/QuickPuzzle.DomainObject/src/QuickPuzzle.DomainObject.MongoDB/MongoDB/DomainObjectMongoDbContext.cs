using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace QuickPuzzle.DomainObject.MongoDB
{
    [ConnectionStringName(DomainObjectDbProperties.ConnectionStringName)]
    public class DomainObjectMongoDbContext : AbpMongoDbContext, IDomainObjectMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureDomainObject();
        }
    }
}