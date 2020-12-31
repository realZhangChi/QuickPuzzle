using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace QuickPuzzle.ProjectManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ProjectManagementDomainSharedModule)
    )]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpDataModule))]
    [DependsOn(typeof(AbpMultiTenancyModule))]
    public class ProjectManagementDomainModule : AbpModule
    {

    }
}
