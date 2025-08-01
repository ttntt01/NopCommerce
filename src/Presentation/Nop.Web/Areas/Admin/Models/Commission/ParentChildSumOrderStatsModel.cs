using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Commission;

/// <summary>
/// Represents a parent child sum order stats model
/// </summary>
public partial record ParentChildSumOrderStatsModel : BaseNopEntityModel
{
    #region Properties

    public int ParentId { get; set; }

    public string ParentEmail { get; set; }

    public int Year { get; set; }

    public int Month { get; set; }

    public string CurrencyCode { get; set; }

    public decimal CurrencyRate { get; set; }

    public decimal TotalOrderAmount { get; set; }
    
    public int TotalOrderCount { get; set;}

    public DateTime CreatedDateTimeUtc { get; set; }

    public DateTime LastUpdatedTimeUtc { get; set; }

    public bool IsPaid { get; set; }

    public decimal PayAmount { get; set; }

    public DateTime ExecuteStartDateTime {  get; set; }

    public DateTime ExecuteEndDateTime {  get; set; }

    public string Status { get; set; }

    #endregion
}
