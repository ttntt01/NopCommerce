using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Commission;

/// <summary>
/// Represents a parent child sum order stats model
/// </summary>
public partial record ParentChildSumOrderStatsModel : BaseNopEntityModel
{
    #region Properties

    [NopResourceDisplayName("Admin.CommissionOrderStats.ParentId")]
    public int ParentId { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.ParentEmail")]
    public string ParentEmail { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.Year")]
    public int Year { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.Month")]
    public int Month { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.CurrencyCode")]
    public string CurrencyCode { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.CurrencyRate")]
    public decimal CurrencyRate { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.TotalOrderAmount")]
    public decimal TotalOrderAmount { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.TotalOrderCount")]
    public int TotalOrderCount { get; set;}

    [NopResourceDisplayName("Admin.CommissionOrderStats.CreatedDateTimeUtc")]
    public DateTime CreatedDateTimeUtc { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.LastUpdatedTimeUtc")]
    public DateTime LastUpdatedTimeUtc { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.IsPaid")]
    public bool IsPaid { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.PayAmount")]
    public decimal PayAmount { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.ExecuteStartDateTime")]
    public DateTime ExecuteStartDateTime {  get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.ExecuteEndDateTime")]
    public DateTime ExecuteEndDateTime {  get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.Status")]
    public string Status { get; set; }


    //User bank details
    [NopResourceDisplayName("Admin.CommissionOrderStats.BankName")]
    public string BankName { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.BranchName")]
    public string BranchName { get; set;}

    [NopResourceDisplayName("Admin.CommissionOrderStats.BranchAddress")]
    public string BranchAddress { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.AccountHolderName")]
    public string AccountHolderName { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.AccountNumber")]
    public string AccountNumber { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.AccountType")]
    public string AccountType { get; set; }

    [NopResourceDisplayName("Admin.CommissionOrderStats.SwiftOrBicCode")]
    public string? SwiftOrBicCode { get; set; }    

    #endregion
}
