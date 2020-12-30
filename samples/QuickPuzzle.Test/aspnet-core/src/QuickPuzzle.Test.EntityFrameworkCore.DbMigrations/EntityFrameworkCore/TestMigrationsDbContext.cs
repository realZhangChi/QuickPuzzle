using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using QuickPuzzle.EntityFactory;

namespace QuickPuzzle.Test.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See TestDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class TestMigrationsDbContext : AbpDbContext<TestMigrationsDbContext>
    {
        private DefaultEntityFactory _entityFactory;

        public TestMigrationsDbContext(
            DbContextOptions<TestMigrationsDbContext> options,
            DefaultEntityFactory entityFactory) 
            : base(options)
        {
            _entityFactory = entityFactory;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside the ConfigureTest method */
            var entityMethod = typeof(ModelBuilder).GetMethod("Entity");
            var type = _entityFactory.GetEntity("test");
            entityMethod.MakeGenericMethod(type)
                           .Invoke(builder, new object[] { });

            builder.ConfigureTest(_entityFactory);
        }
    }
}