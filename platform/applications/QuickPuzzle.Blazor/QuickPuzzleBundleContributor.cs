using Volo.Abp.Bundling;

namespace QuickPuzzle.Blazor
{
    public class QuickPuzzleBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css");
        }
    }
}
