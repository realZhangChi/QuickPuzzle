using QuickPuzzle.ProjectManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QuickPuzzle.ProjectManagement
{
    public abstract class ProjectManagementController : AbpController
    {
        protected ProjectManagementController()
        {
            LocalizationResource = typeof(ProjectManagementResource);
        }
    }
}
