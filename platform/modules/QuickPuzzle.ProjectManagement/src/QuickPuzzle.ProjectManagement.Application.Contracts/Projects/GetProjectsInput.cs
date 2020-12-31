using Volo.Abp.Application.Dtos;

namespace QuickPuzzle.ProjectManagement.Projects
{
    public class GetProjectsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}