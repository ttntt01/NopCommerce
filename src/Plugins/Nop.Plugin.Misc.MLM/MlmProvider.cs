using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core.Domain.Cms;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;

namespace Nop.Plugin.Misc.MLM;
internal class MlmPlugin : BasePlugin, IMiscPlugin
{
    #region Fields

    protected readonly IActionContextAccessor _actionContextAccessor;
    protected readonly ILocalizationService _localizationService;
    protected readonly ISettingService _settingService;
    protected readonly IUrlHelperFactory _urlHelperFactory;
    protected readonly WidgetSettings _widgetSettings;

    #endregion

    #region Ctor

    public MlmPlugin(IActionContextAccessor actionContextAccessor,
        ILocalizationService localizationService,
        ISettingService settingService,
        IUrlHelperFactory urlHelperFactory,
        WidgetSettings widgetSettings)
    {
        _actionContextAccessor = actionContextAccessor;
        _localizationService = localizationService;
        _settingService = settingService;
        _urlHelperFactory = urlHelperFactory;
        _widgetSettings = widgetSettings;
    }

    #endregion


}
