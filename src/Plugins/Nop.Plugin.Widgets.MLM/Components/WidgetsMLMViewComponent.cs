using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.MLM.Components;

[ViewComponent(Name = "WidgetsMLM")]
public class WidgetsMLMViewComponent : NopViewComponent
{
    protected readonly IStoreContext _storeContext;
    protected readonly IStaticCacheManager _staticCacheManager;
    protected readonly ISettingService _settingService;
    protected readonly IPictureService _pictureService;
    protected readonly IWebHelper _webHelper;
    
    public WidgetsMLMViewComponent(IStoreContext storeContext,
        IStaticCacheManager staticCacheManager,
        ISettingService settingService,
        IPictureService pictureService,
        IWebHelper webHelper)
    {
        _storeContext = storeContext;
        _staticCacheManager = staticCacheManager;
        _settingService = settingService;
        _pictureService = pictureService;
        _webHelper = webHelper;
    }

    /// <returns>A task that represents the asynchronous operation</returns>
    public async Task<IViewComponentResult> InvokeAsync()
    {
       
        return View("~/Plugins/Widgets.MLM/Views/Mlm.cshtml");
    }
}