using Localization.Resources.AbpUi;
using QuickPuzzle.DomainObject.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace QuickPuzzle.DomainObject
{
    [DependsOn(
        typeof(DomainObjectApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class DomainObjectHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(DomainObjectHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DomainObjectResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
