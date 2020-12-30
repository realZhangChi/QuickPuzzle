using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QuickPuzzle.EntityFactory;

namespace QuickPuzzle.Test.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class TestMigrationsDbContextFactory : IDesignTimeDbContextFactory<TestMigrationsDbContext>
    {
        private readonly DefaultEntityFactory _entityFactory;

        public TestMigrationsDbContextFactory(DefaultEntityFactory entityFactory)
        {
            _entityFactory = entityFactory;
        }

        public TestMigrationsDbContext CreateDbContext(string[] args)
        {
            TestEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TestMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"), ServerVersion.FromString(configuration["ConnectionStrings:ServerVersion"]));

            return new TestMigrationsDbContext(builder.Options, _entityFactory);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../QuickPuzzle.Test.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
