using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Customers;
using Nop.Services.Common;
using Nop.Services.ParentChild;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Models.Common;
using Nop.Web.Areas.Admin.Models.Home;

namespace Nop.Web.Areas.Admin.Controllers;

public partial class CommissionController : BaseAdminController
{
    #region Fields

    protected readonly IProductModelFactory _productModelFactory;
    protected readonly IParentChildSumOrderStatsService _parentChildSumOrderStatsService;

    #endregion


    #region Ctor

    public CommissionController(IProductModelFactory productModelFactory, IParentChildSumOrderStatsService parentChildSumOrderStatsService)
    {
        _productModelFactory = productModelFactory;
        _parentChildSumOrderStatsService = parentChildSumOrderStatsService;
    }

    #endregion


    #region Methods

    public virtual async Task<IActionResult> Index()
    {    
        //prepare model
        var model = await _productModelFactory.PrepareProductTagSearchModelAsync(new ProductTagSearchModel());

        return View(model);
    }

    #endregion
}
