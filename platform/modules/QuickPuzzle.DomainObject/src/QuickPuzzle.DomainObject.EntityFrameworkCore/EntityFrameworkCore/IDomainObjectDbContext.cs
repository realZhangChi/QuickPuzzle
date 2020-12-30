using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace QuickPuzzle.DomainObject.EntityFrameworkCore
{
    [ConnectionStringName(DomainObjectDbProperties.ConnectionStringName)]
    public interface IDomainObjectDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}