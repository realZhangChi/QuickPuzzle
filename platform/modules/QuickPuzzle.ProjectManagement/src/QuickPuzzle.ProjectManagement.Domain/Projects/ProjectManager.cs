using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Repositories;

namespace QuickPuzzle.ProjectManagement.Projects
{
    public class ProjectManager : DomainService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectManager(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> CreateAsync([NotNull] string name)
        {
            var project = new Project(name, CurrentTenant.Id);
            await _projectRepository.InsertAsync(project);
            return project;
        }

        public async Task ChangeNameAsync(Project project, [NotNull] string name)
        {
            Check.NotNull(project, nameof(project));
            await ValidateNameAsync(name, project.Id);
            project.SetName(name);
        }

        private async Task ValidateNameAsync(string name, Guid? expectedId = null)
        {
            var project = await _projectRepository.FindByNameAsync(name);
            if (project is not null && project.Id != expectedId)
            {
                throw new DuplicateProjectNameException();
            }
        }
    }
}