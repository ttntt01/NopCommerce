using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Catalog;

/// <summary>
/// Represents a product file list model
/// </summary>
public partial record ProductFileListModel : BasePagedListModel<ProductFileModel>
{
    public string ErrorMessage { get; set; }
}
