using AutoMapper;
using QuickPuzzle.ProjectManagement.Projects;

namespace QuickPuzzle.ProjectManagement
{
    public class ProjectApplicationAutoMapperProfile : Profile
    {
        public ProjectApplicationAutoMapperProfile()
        {
            CreateMap<Project, ProjectDto>();
        }
    }
}