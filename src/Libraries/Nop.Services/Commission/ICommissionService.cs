using Nop.Core;
using Nop.Core.Domain.Customers;

namespace Nop.Services.Commission;

/// <summary>
/// Commission service
/// </summary>
public partial interface ICommissionService
{
    /// <summary>
    /// Search parent child sum order stats
    /// </summary>
    /// <param name="year">Year identifiers</param>
    /// <param name="month">Month identifiers</param>
    /// <param name="parentEmail">ParentEmail identifier</param>
    /// <param name="isPaid">IsPaid identifier; 0 to load all records</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the parent child sum order stats
    /// </returns>
    Task<IPagedList<ParentChildSumOrderStats>> SearchParentChildSumOrderStatsAsync(int year, int month, string parentEmail, bool? isPaid, 
        int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);

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
