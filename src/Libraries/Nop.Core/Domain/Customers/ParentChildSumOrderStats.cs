namespace Nop.Core.Domain.Customers;

public partial class ParentChildSumOrderStats : BaseEntity
{    
    /// <summary>
    /// Gets or sets the ParentId
    /// </summary>
    public int ParentId { get; set; }

    /// <summary>
    /// Gets or sets the ParentEmail
    /// </summary>
    public string ParentEmail { get; set; }

    /// <summary>
    /// Gets or sets the Year
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the Month
    /// </summary>
    public int Month { get; set; }

    /// <summary>
    /// Gets or sets the CurrencyCode
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Gets or sets the CurrencyRate
    /// </summary>
    public decimal CurrencyRate { get; set; }

    /// <summary>
    /// Gets or sets the TotalOrderAmount
    /// </summary>
    public decimal TotalOrderAmount { get; set; }

    /// <summary>
    /// Gets or sets the TotalOrderCount
    /// </summary>
    public int TotalOrderCount { get; set; }

    /// <summary>
    /// Gets or sets the CreatedDateTimeUtc
    /// </summary>
    public DateTime CreatedDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the LastUpdatedTimeUtc
    /// </summary>
    public DateTime LastUpdatedTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the IsPaid
    /// </summary>
    public bool IsPaid { get; set; }

    /// <summary>
    /// Gets or sets the PayAmount
    /// </summary>
    public decimal PayAmount { get; set; }
}
