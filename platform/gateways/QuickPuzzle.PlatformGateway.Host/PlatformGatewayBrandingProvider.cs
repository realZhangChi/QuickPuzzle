using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace QuickPuzzle.PlatformGateway
{
    [Dependency(ReplaceServices = true)]
    public class PlatformGatewayBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "PlatformGateway";
    }
}
