using Nop.Web.Areas.Admin.Models.Commission;

namespace Nop.Web.Areas.Admin.Factories;

/// <summary>
/// Represents the commission model factory
/// </summary>
public partial interface ICommissionModelFctory
{
    /// <summary>
    /// Prepare commission search model
    /// </summary>
    /// <param name="searchModel">Commission search model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the commission search model
    /// </returns>
    Task<CommissionSearchModel> PrepareCommissionSearchModelAsync(CommissionSearchModel searchModel);


    /// Prepare paged parent child sum order stats list model
    /// </summary>
    /// <param name="searchModel">ParentChildSumOrderStats search model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the parent child sum order stats list model
    /// </returns>
    Task<ParentChildSumOrderStatsListModel> PrepareParentChildSumOrderStatsListModelAsync(CommissionSearchModel searchModel);
}
