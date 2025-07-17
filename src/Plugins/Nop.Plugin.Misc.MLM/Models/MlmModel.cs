using Nop.Core;

namespace Nop.Plugin.Misc.MLM.Model;

/// <summary>
/// Represents MLM model
/// </summary>
public class MlmModel : BaseEntity
{
    #region Properties

    public int ParentId { get; set; }
    public string ParentName { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public DateTime CreatedDateTimeUTC { get; set; } = DateTime.UtcNow;

    #endregion
}
