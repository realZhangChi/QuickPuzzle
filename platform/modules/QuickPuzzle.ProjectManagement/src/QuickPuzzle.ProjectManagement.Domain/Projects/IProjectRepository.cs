using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;

namespace QuickPuzzle.ProjectManagement.Projects
{
    public interface IProjectRepository : IBasicRepository<Project, Guid>
    {
        Task<List<Project>> GetListAsync(
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    string filter = null,
                    bool includeDetails = false,
                    CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(string filter = null, CancellationToken cancellationToken = default);

        Task<Project> FindByNameAsync(
            string name,
            bool includeDetails = true,
            CancellationToken cancellationToken = default);
    }
}