using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using QuickPuzzle.ProjectManagement.Projects;

namespace QuickPuzzle.ProjectManagement.EntityFrameworkCore
{
    [ConnectionStringName(ProjectManagementDbProperties.ConnectionStringName)]
    public interface IProjectManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        public DbSet<Project> Projects { get; }
    }
}