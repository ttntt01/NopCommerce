using Nop.Core.Domain.Customers;

namespace Nop.Services.ParentChild;

public partial interface IParentChildSumOrderStatsService
{    
    /// <summary>
    /// Get parent child sum order stats by parent id
    /// </summary>
    /// <param name="parentId">ParentId</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the customer
    /// </returns>
    Task<ParentChildSumOrderStats> GetParentChildSumOrderStatsAsync(int parentId, int year, int month);
}
