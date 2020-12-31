using System;
using Volo.Abp.Application.Dtos;

namespace QuickPuzzle.ProjectManagement.Projects
{
    public class ProjectDto : ExtensibleCreationAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}