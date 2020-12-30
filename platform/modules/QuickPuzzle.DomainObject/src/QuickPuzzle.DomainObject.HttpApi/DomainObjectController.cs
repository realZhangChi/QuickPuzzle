using QuickPuzzle.DomainObject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QuickPuzzle.DomainObject
{
    public abstract class DomainObjectController : AbpController
    {
        protected DomainObjectController()
        {
            LocalizationResource = typeof(DomainObjectResource);
        }
    }
}
