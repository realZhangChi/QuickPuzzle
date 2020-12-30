using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace QuickPuzzle.DomainObject.EntityFrameworkCore
{
    public class DomainObjectHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<DomainObjectHttpApiHostMigrationsDbContext>
    {
        public DomainObjectHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<DomainObjectHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DomainObject"));

            return new DomainObjectHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
