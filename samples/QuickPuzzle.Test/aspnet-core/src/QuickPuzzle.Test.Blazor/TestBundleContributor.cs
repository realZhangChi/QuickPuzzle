using Volo.Abp.Bundling;

namespace QuickPuzzle.Test.Blazor
{
    public class TestBundleContributor : IBundleContributor
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
