using QuickPuzzle.ProjectManagement.Localization;
using Volo.Abp.Application.Services;

namespace QuickPuzzle.ProjectManagement
{
    public abstract class ProjectManagementAppService : ApplicationService
    {
        protected ProjectManagementAppService()
        {
            LocalizationResource = typeof(ProjectManagementResource);
            ObjectMapperContext = typeof(ProjectManagementApplicationModule);
        }
    }
}
