using Nop.Core.Domain.Customers;

namespace Nop.Services.ParentChild;

public partial interface IParentChildLineStatsService
{
    /// <summary>
    /// Get list of parent child line stats by parent id
    /// </summary>
    /// <param name="parentId">ParentId</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the customer
    /// </returns>
    Task<List<ParentChildLineStats>> GetParentChildLineStatsListAsync(int parentId);
}
