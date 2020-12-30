using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace QuickPuzzle.DomainObject.EntityFrameworkCore
{
    public class DomainObjectHttpApiHostMigrationsDbContext : AbpDbContext<DomainObjectHttpApiHostMigrationsDbContext>
    {
        public DomainObjectHttpApiHostMigrationsDbContext(DbContextOptions<DomainObjectHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureDomainObject();
        }
    }
}
