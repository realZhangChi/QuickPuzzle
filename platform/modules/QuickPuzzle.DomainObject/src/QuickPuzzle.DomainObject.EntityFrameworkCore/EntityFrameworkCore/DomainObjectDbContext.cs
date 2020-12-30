using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace QuickPuzzle.DomainObject.EntityFrameworkCore
{
    [ConnectionStringName(DomainObjectDbProperties.ConnectionStringName)]
    public class DomainObjectDbContext : AbpDbContext<DomainObjectDbContext>, IDomainObjectDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public DomainObjectDbContext(DbContextOptions<DomainObjectDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureDomainObject();
        }
    }
}