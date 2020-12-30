using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace QuickPuzzle.ProjectManagement
{
    [DependsOn(
        typeof(ProjectManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class ProjectManagementApplicationContractsModule : AbpModule
    {

    }
}
