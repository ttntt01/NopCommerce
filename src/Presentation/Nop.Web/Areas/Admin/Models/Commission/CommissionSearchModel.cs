using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Commission;


/// <summary>
/// Represents a commission model
/// </summary>
public partial record CommissionSearchModel : BaseSearchModel
{
    #region Properties

    [NopResourceDisplayName("Admin.Commission.ParentEmail")]
    public string ParentEmail { get; set; }

    [NopResourceDisplayName("Admin.Commission.Year")]
    public int Year { get; set; }

    [NopResourceDisplayName("Admin.Commission.Month")]
    public int Month { get; set; }

    // This holds the selected value from the dropdown
    [NopResourceDisplayName("Admin.Commission.SelectedIsPaid")]
    public int? SelectedIsPaid { get; set; }

    // This provides the dropdown options
    public IList<SelectListItem> IsPaidList { get; set; } = new List<SelectListItem>
    {
        new SelectListItem { Text = "-- Select --", Value = "" },
        new SelectListItem { Text = "Yes", Value = "1" },
        new SelectListItem { Text = "No", Value = "0" }
    };

    #endregion
}
