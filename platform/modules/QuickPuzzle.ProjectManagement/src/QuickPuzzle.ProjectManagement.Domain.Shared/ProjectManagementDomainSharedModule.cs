using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using QuickPuzzle.ProjectManagement.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace QuickPuzzle.ProjectManagement
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class ProjectManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ProjectManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ProjectManagementResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/ProjectManagement");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ProjectManagement", typeof(ProjectManagementResource));
            });
        }
    }
}
