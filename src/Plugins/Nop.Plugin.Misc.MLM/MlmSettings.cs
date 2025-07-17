using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.MLM;

public class MlmSettings : ISettings
{
    #region Common

    /// <summary>
    /// Gets or sets a value indicating whether the plugin is enabled
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating parent/ agent id
    /// </summary>
    public int ParentId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating parent/ agent name
    /// </summary>
    public string ParentName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating customer/ downline id
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating customer/ downline name
    /// </summary>
    public string CustomerName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating the record create datetime
    /// </summary>
    public DateTime CreatedDateTimeUTC { get; set; } = DateTime.UtcNow;

    #endregion
}
