using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Media;

public partial record FileModel : BaseNopEntityModel
{
    public int ProductId { get; set; }
    public string MimeType { get; set; }
    public string SeoFilename { get; set; }
    public string VirtualPath { get; set;}
}
