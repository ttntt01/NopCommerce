using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Catalog;

/// <summary>
/// Represents a product file model
/// </summary>
public partial record ProductFileModel : BaseNopEntityModel
{
    #region Properties

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.File.Fields.ProductId")]
    public int ProductId { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.File.Fields.FileId")]
    public int FileId { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.File.Fields.FileUrl")]
    public string FileUrl { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.File.Fields.FileName")]
    public string FileName { get; set; }

    public bool IsDeleted { get; set; }

    public string OverrideAltAttribute { get; set; }

    public string OverrideTitleAttribute { get; set; }

    #endregion
}
