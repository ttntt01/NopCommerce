namespace Nop.Core.Domain.Customers;

/// <summary>
/// Represents a customer agent
/// </summary>
public partial class CustomerAgent : BaseEntity
{
    /// <summary>
    /// Gets or sets the agent identifier
    /// </summary>
    public int AgentId { get; set; }

    /// <summary>
    /// Gets or sets the agent username
    /// </summary>
    public string AgentUsername { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the customer username
    /// </summary>
    public string CustomerUsername { get; set; }    

    /// <summary>
    /// Gets or sets the created datetime
    /// </summary>
    public string CreatedDateTime { get; set; }
}
