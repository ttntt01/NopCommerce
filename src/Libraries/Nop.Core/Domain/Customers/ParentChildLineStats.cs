namespace Nop.Core.Domain.Customers;

public partial class ParentChildLineStats : BaseEntity
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
    /// Gets or sets the LineLevel
    /// </summary>
    public string LineLevel { get; set; }

    /// <summary>
    /// Gets or sets the ChildCount
    /// </summary>
    public int ChildCount { get; set; }

    /// <summary>
    /// Gets or sets the CreatedDateTimeUtc
    /// </summary>
    public DateTime CreatedDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the LastUpdatedTimeUtc
    /// </summary>
    public DateTime LastUpdatedTimeUtc { get; set; }
}
