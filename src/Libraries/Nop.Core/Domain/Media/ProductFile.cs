namespace Nop.Core.Domain.Media;

/// <summary>
/// Represents a ProductFile
/// </summary>
public partial class ProductFile : BaseEntity
{    
    /// <summary>
     /// Gets or sets the product Id
     /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the file mime type
    /// </summary>
    public string MimeType { get; set; }

    /// <summary>
    /// Gets or sets the SEO friendly filename of the file
    /// </summary>
    public string SeoFilename { get; set; }

    /// <summary>
    /// Gets or sets the "alt" attribute for the file. If empty, then a default rule will be used (e.g. product name)
    /// </summary>
    public string AltAttribute { get; set; }

    /// <summary>
    /// Gets or sets the "title" attribute for the file. If empty, then a default rule will be used (e.g. product name)
    /// </summary>
    public string TitleAttribute { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the file is new
    /// </summary>
    public bool IsNew { get; set; }

    /// <summary>
    /// Gets or sets the file virtual path
    /// </summary>
    public string VirtualPath { get; set; }

    /// <summary>
    /// Gets or sets the file to soft delete
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets the file created datetime utc
    /// </summary>
    public DateTime CreatedDateTimeUTC { get; set; }

    /// <summary>
    /// Gets or sets the file updated datetime utc
    /// </summary>
    public DateTime UpdatedDateTimeUTC { get; set; }
}
