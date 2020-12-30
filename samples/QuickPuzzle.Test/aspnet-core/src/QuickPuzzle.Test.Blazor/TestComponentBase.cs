using QuickPuzzle.Test.Localization;
using Volo.Abp.AspNetCore.Components;

namespace QuickPuzzle.Test.Blazor
{
    public abstract class TestComponentBase : AbpComponentBase
    {
        protected TestComponentBase()
        {
            LocalizationResource = typeof(TestResource);
        }
    }
}
