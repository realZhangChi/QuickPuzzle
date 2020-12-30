using QuickPuzzle.DomainObject.Localization;
using Volo.Abp.Application.Services;

namespace QuickPuzzle.DomainObject
{
    public abstract class DomainObjectAppService : ApplicationService
    {
        protected DomainObjectAppService()
        {
            LocalizationResource = typeof(DomainObjectResource);
            ObjectMapperContext = typeof(DomainObjectApplicationModule);
        }
    }
}
