using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace QuickPuzzle.ProjectManagement.Projects
{
    [Controller]
    [RemoteService(Name = ProjectManagementRemoteServiceConsts.RemoteServiceName)]
    [Area("project-management")]
    [Route("api/project-management/project")]
    public class ProjectController : ProjectManagementController, IProjectAppService
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectController(IProjectAppService sampleAppService)
        {
            _projectAppService = sampleAppService;
        }

        [HttpPost]
        public virtual Task<ProjectDto> CreateAsync(ProjectCreateDto input)
        {
            ValidateModel();
            return _projectAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _projectAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ProjectDto> GetAsync(Guid id)
        {
            return _projectAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ProjectDto>> GetListAsync(GetProjectsInput input)
        {
            return _projectAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ProjectDto> UpdateAsync(Guid id, ProjectUpdateDto input)
        {
            return _projectAppService.UpdateAsync(id, input);
        }
    }
}
