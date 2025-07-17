using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.MLM;

public class MlmProcessor : BasePlugin, IWidgetPlugin
{
    public bool HideInWidgetList => throw new NotImplementedException();

    public Type GetWidgetViewComponent(string widgetZone)
    {
        throw new NotImplementedException();
    }

    public Task<IList<string>> GetWidgetZonesAsync()
    {
        return Task.FromResult<IList<string>>(new List<string>
        {
            PublicWidgetZones.AddressBottom,
            PublicWidgetZones.OrderSummaryBillingAddress,
            PublicWidgetZones.OrderSummaryShippingAddress,
            PublicWidgetZones.OrderDetailsBillingAddress,
            PublicWidgetZones.OrderDetailsShippingAddress,

            AdminWidgetZones.OrderBillingAddressDetailsBottom,
            AdminWidgetZones.OrderShippingAddressDetailsBottom
        });
    }

    public override Task InstallAsync()
    {
        return base.InstallAsync();
    }

    public override Task UninstallAsync()
    {
        return base.UninstallAsync();
    }
}
