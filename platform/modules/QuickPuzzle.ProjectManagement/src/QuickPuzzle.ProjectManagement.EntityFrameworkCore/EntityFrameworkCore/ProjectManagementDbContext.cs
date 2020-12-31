using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using QuickPuzzle.ProjectManagement.Projects;

namespace QuickPuzzle.ProjectManagement.EntityFrameworkCore
{
    [ConnectionStringName(ProjectManagementDbProperties.ConnectionStringName)]
    public class ProjectManagementDbContext : AbpDbContext<ProjectManagementDbContext>, IProjectManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Project> Projects { get; set; }

        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureProjectManagement();
        }
    }
}