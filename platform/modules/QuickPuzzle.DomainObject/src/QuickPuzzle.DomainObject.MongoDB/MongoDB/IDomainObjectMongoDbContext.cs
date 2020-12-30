using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace QuickPuzzle.DomainObject.MongoDB
{
    [ConnectionStringName(DomainObjectDbProperties.ConnectionStringName)]
    public interface IDomainObjectMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
