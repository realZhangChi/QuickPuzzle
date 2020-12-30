using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace QuickPuzzle.DomainObject
{
    [DependsOn(
        typeof(DomainObjectDomainModule),
        typeof(DomainObjectApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class DomainObjectApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<DomainObjectApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<DomainObjectApplicationModule>(validate: true);
            });
        }
    }
}
