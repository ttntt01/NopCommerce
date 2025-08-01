using Nop.Core.Domain.Customers;
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

    /// <summary>
    /// Prepare paged parent child sum order stats list model
    /// </summary>
    /// <param name="searchModel">ParentChildSumOrderStats search model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the parent child sum order stats list model
    /// </returns>
    Task<ParentChildSumOrderStatsListModel> PrepareParentChildSumOrderStatsListModelAsync(CommissionSearchModel searchModel);

    /// <summary>
    /// Prepare parent child sum order stats model
    /// </summary>
    /// <param name="id">Id search</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the parent child sum order stats model
    /// </returns>
    Task<ParentChildSumOrderStats> PrepareParentChildSumOrderStatsModelAsync(int id);

    /// <summary>
    /// Update commission paid
    /// </summary>
    /// <param name="parentChildSumOrderStats">Parent Child Sum Order Stats identifiers</param>
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// Parameters contains the parent child sum order stats
    /// </returns>
    Task<ParentChildSumOrderStats> UpdateIsPaidStatusAsync(ParentChildSumOrderStats parentChildSumOrderStats);
}
