using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Catalog;

/// <summary>
/// Represents a product file model
/// </summary>
public partial record ProductFileModel : BaseNopEntityModel
{
    #region Properties

    public int ProductId { get; set; }

    public int FileId { get; set; }

    public string FileUrl { get; set; }

    public string FileName { get; set; }

    public bool IsDeleted { get; set; }

    public string OverrideAltAttribute { get; set; }

    public string OverrideTitleAttribute { get; set; }

    #endregion
}
