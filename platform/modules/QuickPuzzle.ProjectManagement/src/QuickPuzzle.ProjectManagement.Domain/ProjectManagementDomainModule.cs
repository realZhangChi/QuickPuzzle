using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace QuickPuzzle.ProjectManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ProjectManagementDomainSharedModule)
    )]
    public class ProjectManagementDomainModule : AbpModule
    {

    }
}
