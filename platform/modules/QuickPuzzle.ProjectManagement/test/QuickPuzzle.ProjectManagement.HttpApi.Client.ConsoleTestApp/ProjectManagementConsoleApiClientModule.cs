using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace QuickPuzzle.ProjectManagement
{
    [DependsOn(
        typeof(ProjectManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ProjectManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
