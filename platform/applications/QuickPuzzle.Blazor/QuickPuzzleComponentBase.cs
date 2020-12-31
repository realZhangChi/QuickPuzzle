using Volo.Abp.AspNetCore.Components;

namespace QuickPuzzle.Blazor
{
    public abstract class QuickPuzzleComponentBase : AbpComponentBase
    {
        protected QuickPuzzleComponentBase()
        {
            // LocalizationResource = typeof(QuickPuzzleResource);
        }
    }
}
