using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace QuickPuzzle.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class QuickPuzzleBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "QuickPuzzle";
    }
}
