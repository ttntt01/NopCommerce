using Microsoft.AspNetCore.Mvc;
using Nop.Services.ParentChild;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Models.Commission;

namespace Nop.Web.Areas.Admin.Controllers;

public partial class CommissionController : BaseAdminController
{
    #region Fields

    protected readonly IPermissionService _permissionService;
    protected readonly ICommissionModelFctory _commissionModelFctory;
    protected readonly IParentChildSumOrderStatsService _parentChildSumOrderStatsService;

    #endregion


    #region Ctor

    public CommissionController(IPermissionService permissionService, ICommissionModelFctory commissionModelFctory, IParentChildSumOrderStatsService parentChildSumOrderStatsService)
    {
        _permissionService = permissionService;
        _commissionModelFctory = commissionModelFctory;
        _parentChildSumOrderStatsService = parentChildSumOrderStatsService;
    }

    #endregion


    #region Methods

    public virtual async Task<IActionResult> Index()
    {    
        //prepare model
        var model = await _commissionModelFctory.PrepareCommissionSearchModelAsync(new CommissionSearchModel());

        return View(model);
    }

    [HttpPost]
    public virtual async Task<IActionResult> ParentChildSumOrderStatsList(CommissionSearchModel searchModel)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProducts))
            return await AccessDeniedDataTablesJson();

        if (searchModel.Year.Equals(0))
            searchModel.Year = DateTime.Now.Year;

        if (searchModel.Month.Equals(0))    
            searchModel.Month = DateTime.Now.Month;

        //prepare model
        var model = await _commissionModelFctory.PrepareParentChildSumOrderStatsListModelAsync(searchModel);

        return Json(model);
    }

    #endregion
}
