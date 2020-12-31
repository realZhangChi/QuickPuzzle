using System;
using Volo.Abp.Application.Services;

namespace QuickPuzzle.ProjectManagement.Projects
{
    public interface IProjectAppService : ICrudAppService<ProjectDto, Guid, GetProjectsInput, ProjectCreateDto, ProjectUpdateDto>
    {
    }
}
