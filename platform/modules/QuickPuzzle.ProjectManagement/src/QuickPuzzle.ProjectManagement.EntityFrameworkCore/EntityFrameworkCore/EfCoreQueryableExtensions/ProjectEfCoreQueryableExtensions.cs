using System.Linq;
using QuickPuzzle.ProjectManagement.Projects;

namespace QuickPuzzle.ProjectManagement.EntityFrameworkCore
{
    public static class ProjectEfCoreQueryableExtensions
    {
        public static IQueryable<Project> IncludeDetails(this IQueryable<Project> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable;
        }
    }
}