namespace Nop.Core.Domain.Customers;

public partial class ParentChildRelations : BaseEntity
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
    /// Gets or sets the ChildId
    /// </summary>
    public int ChildId { get; set; }

    /// <summary>
    /// Gets or sets the ChildEmail
    /// </summary>
    public string ChildEmail { get; set; }

    /// <summary>
    /// Gets or sets the CreatedDateTimeUtc
    /// </summary>
    public DateTime CreatedDateTimeUtc { get; set; }
}
