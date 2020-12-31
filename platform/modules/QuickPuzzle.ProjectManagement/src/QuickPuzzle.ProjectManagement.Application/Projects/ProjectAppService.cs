using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using QuickPuzzle.ProjectManagement.Permissions;
using Volo.Abp.Application.Dtos;

namespace QuickPuzzle.ProjectManagement.Projects
{
    [Authorize(ProjectManagementPermissions.Project.Default)]
    public class ProjectAppService : ProjectManagementAppService, IProjectAppService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ProjectManager _projectManager;

        public ProjectAppService(
            IProjectRepository projectRepository,
            ProjectManager projectManager
        )
        {
            _projectRepository = projectRepository;
            _projectManager = projectManager;
        }

        [Authorize(ProjectManagementPermissions.Project.Create)]
        public virtual async Task<ProjectDto> CreateAsync(ProjectCreateDto input)
        {
            var project = await _projectManager.CreateAsync(input.Name);
            await _projectRepository.InsertAsync(project);

            return ObjectMapper.Map<Project, ProjectDto>(project);
        }

        [Authorize(ProjectManagementPermissions.Project.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var project = await _projectRepository.FindAsync(id);
            if (project is null)
            {
                return;
            }

            await _projectRepository.DeleteAsync(project);
        }

        [Authorize(ProjectManagementPermissions.Project.Get)]
        public virtual async Task<ProjectDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Project, ProjectDto>(
                await _projectRepository.GetAsync(id)
            );
        }

        [Authorize(ProjectManagementPermissions.Project.Get)]
        public virtual async Task<PagedResultDto<ProjectDto>> GetListAsync(GetProjectsInput input)
        {
            var count = await _projectRepository.GetCountAsync(input.Filter);
            var list = await _projectRepository.GetListAsync(
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount,
                input.Filter);

            return new PagedResultDto<ProjectDto>(
                count,
                ObjectMapper.Map<List<Project>, List<ProjectDto>>(list)
            );
        }

        public virtual async Task<ProjectDto> UpdateAsync(Guid id, ProjectUpdateDto input)
        {
            var project = await _projectRepository.GetAsync(id);
            await _projectManager.ChangeNameAsync(project, input.Name);

            return ObjectMapper.Map<Project, ProjectDto>(project);
        }
    }
}