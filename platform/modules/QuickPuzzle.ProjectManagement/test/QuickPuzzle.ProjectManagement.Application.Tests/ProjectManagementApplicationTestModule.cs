using Volo.Abp.Modularity;

namespace QuickPuzzle.ProjectManagement
{
    [DependsOn(
        typeof(ProjectManagementApplicationModule),
        typeof(ProjectManagementDomainTestModule)
        )]
    public class ProjectManagementApplicationTestModule : AbpModule
    {

    }
}
