using Microsoft.AspNetCore.Builder;
using Volo.Abp.Modularity;
using Volo.Abp.AutoMapper;
using QuickPuzzle.CookiePolicy;

namespace QuickPuzzle
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class SharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            Configure<CookiePolicyOptions>(options =>
                        {
                            options.ConfigSameSite();
                        });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}