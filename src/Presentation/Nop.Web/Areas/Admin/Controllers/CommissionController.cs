using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Customers;
using Nop.Services.ParentChild;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Models.Commission;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers;

public partial class CommissionController : BaseAdminController
{
    #region Fields

    protected readonly IPermissionService _permissionService;
    protected readonly ICommissionModelFctory _commissionModelFctory;
    protected readonly IParentChildSumOrderStatsService _parentChildSumOrderStatsService;
    protected readonly IParentBankDetailsService _parentBankDetailsService;

    #endregion


    #region Ctor

    public CommissionController(IPermissionService permissionService, ICommissionModelFctory commissionModelFctory, IParentChildSumOrderStatsService parentChildSumOrderStatsService, IParentBankDetailsService parentBankDetailsService)
    {
        _permissionService = permissionService;
        _commissionModelFctory = commissionModelFctory;
        _parentChildSumOrderStatsService = parentChildSumOrderStatsService;
        _parentBankDetailsService = parentBankDetailsService;        
    }

    #endregion


    #region Methods

    public virtual async Task<IActionResult> Index()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCustomers))
            return AccessDeniedView();

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

    public virtual async Task<IActionResult> Edit(int id)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCustomers))
            return AccessDeniedView();

        //prepare model
        var entity = await _commissionModelFctory.PrepareParentChildSumOrderStatsModelAsync(id);
        if (entity == null)
            return null;

        var parentBankDetails = await _parentBankDetailsService.GetParentBankDetailsAsync(entity.ParentId);

        var model = new ParentChildSumOrderStatsModel
        {
            Id = entity.Id,
            ParentId = entity.ParentId,
            ParentEmail = entity.ParentEmail,
            Year = entity.Year,
            Month = entity.Month,
            CurrencyCode = entity.CurrencyCode,
            CurrencyRate = entity.CurrencyRate,
            TotalOrderAmount = entity.TotalOrderAmount,
            TotalOrderCount = entity.TotalOrderCount,
            CreatedDateTimeUtc = entity.CreatedDateTimeUtc,
            LastUpdatedTimeUtc = entity.LastUpdatedTimeUtc,
            IsPaid = entity.IsPaid,
            PayAmount = entity.PayAmount,
            ExecuteStartDateTime = entity.ExecuteStartDateTime,
            ExecuteEndDateTime = entity.ExecuteEndDateTime,
            Status = entity.IsPaid ? "Paid" : "Not Paid",
            BankName = parentBankDetails?.BankName ?? "",
            BranchName = parentBankDetails?.BranchName ?? "",
            BranchAddress = parentBankDetails?.BranchAddress ?? "",
            AccountHolderName = parentBankDetails?.AccountHolderName ?? "",
            AccountNumber = parentBankDetails?.AccountNumber ?? "",
            AccountType = parentBankDetails?.AccountType ?? "",
            SwiftOrBicCode = parentBankDetails?.SwiftOrBicCode ?? ""
        };

        return View(model);
    }

    [HttpPost, ParameterBasedOnFormName("commission-update", "continueEditing")]
    public virtual async Task<IActionResult> Update(ParentChildSumOrderStatsModel model)
    {
        var parentChildSumOrderStats = new ParentChildSumOrderStats
        {
            Id = model.Id,
            ParentId = model.ParentId,
            ParentEmail = model.ParentEmail,
            Year = model.Year,
            Month = model.Month,
            CurrencyCode = model.CurrencyCode,
            CurrencyRate = model.CurrencyRate,
            TotalOrderAmount = model.TotalOrderAmount,
            TotalOrderCount = model.TotalOrderCount,
            CreatedDateTimeUtc = model.CreatedDateTimeUtc,
            LastUpdatedTimeUtc = model.LastUpdatedTimeUtc,
            IsPaid = model.IsPaid,
            PayAmount = model.PayAmount,
            ExecuteStartDateTime = model.ExecuteStartDateTime,
            ExecuteEndDateTime = model.ExecuteEndDateTime
        };

        var entity = await _commissionModelFctory.UpdateIsPaidStatusAsync(parentChildSumOrderStats);

        if (entity == null)
        {
            var model1 = new ParentChildSumOrderStatsModel
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                ParentEmail = entity.ParentEmail,
                Year = entity.Year,
                Month = entity.Month,
                CurrencyCode = entity.CurrencyCode,
                CurrencyRate = entity.CurrencyRate,
                TotalOrderAmount = entity.TotalOrderAmount,
                TotalOrderCount = entity.TotalOrderCount,
                CreatedDateTimeUtc = entity.CreatedDateTimeUtc,
                LastUpdatedTimeUtc = entity.LastUpdatedTimeUtc,
                IsPaid = entity.IsPaid,
                PayAmount = entity.PayAmount,
                ExecuteStartDateTime = entity.ExecuteStartDateTime,
                ExecuteEndDateTime = entity.ExecuteEndDateTime,
                Status = entity.IsPaid ? "Successfully update - Paid" : "Fail to update - Not Paid"
            };

            return View("Edit", model1);

        }
        else
        {
            var model1 = new ParentChildSumOrderStatsModel
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                ParentEmail = entity.ParentEmail,
                Year = entity.Year,
                Month = entity.Month,
                CurrencyCode = entity.CurrencyCode,
                CurrencyRate = entity.CurrencyRate,
                TotalOrderAmount = entity.TotalOrderAmount,
                TotalOrderCount = entity.TotalOrderCount,
                CreatedDateTimeUtc = entity.CreatedDateTimeUtc,
                LastUpdatedTimeUtc = entity.LastUpdatedTimeUtc,
                IsPaid = entity.IsPaid,
                PayAmount = entity.PayAmount,
                ExecuteStartDateTime = entity.ExecuteStartDateTime,
                ExecuteEndDateTime = entity.ExecuteEndDateTime,
                Status = entity.IsPaid ? "Successfully update - Paid" : "Fail to update - Not Paid"
            };

            return View("Edit", model1);
        }  
    }

    #endregion
}
