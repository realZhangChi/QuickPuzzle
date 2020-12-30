using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace QuickPuzzle.ProjectManagement.EntityFrameworkCore
{
    public class ProjectManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ProjectManagementHttpApiHostMigrationsDbContext>
    {
        public ProjectManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ProjectManagementHttpApiHostMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("ProjectManagement"), ServerVersion.FromString(configuration["ConnectionStrings:ServerVersion"]));

            return new ProjectManagementHttpApiHostMigrationsDbContext(builder.Options);
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
