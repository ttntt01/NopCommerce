namespace Nop.Core.Domain.Customers;

public partial class ParentBankDetails : BaseEntity
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
    /// Gets or sets the BankName
    /// </summary>
    public string BankName { get; set; }

    /// <summary>
    /// Gets or sets the BranchName
    /// </summary>
    public string BranchName { get; set; }

    /// <summary>
    /// Gets or sets the BranchAddress
    /// </summary>
    public string BranchAddress { get; set; }

    /// <summary>
    /// Gets or sets the AccountHolderName
    /// </summary>
    public string AccountHolderName { get; set; }

    /// <summary>
    /// Gets or sets the AccountNumber
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets the AccountType
    /// </summary>
    public string AccountType { get; set; }

    /// <summary>
    /// Gets or sets the SwiftOrBicCode
    /// </summary>
    public string SwiftOrBicCode { get; set; }

    /// <summary>
    /// Gets or sets the CurrencyCode
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Gets or sets the CreatedDateTimeUtc
    /// </summary>
    public DateTime CreatedDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the LastUpdatedTimeUtc
    /// </summary>
    public DateTime LastUpdatedTimeUtc { get; set; }
}

