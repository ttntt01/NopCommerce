namespace Nop.Core.Domain.Media;

/// <summary>
/// Represents a file binary data
/// </summary>
public partial class FileBinary : BaseEntity
{
    /// <summary>
    /// Gets or sets the file identifier
    /// </summary>
    public int FileId { get; set; }

    /// <summary>
    /// Gets or sets the file binary
    /// </summary>
    public byte[] BinaryData { get; set; }
}
