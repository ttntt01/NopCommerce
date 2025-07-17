using Nop.Core.Domain.Customers;
using Nop.Data;

namespace Nop.Services.ParentChild;

public partial class ParentChildLineStatsService : IParentChildLineStatsService
{
    #region Fields

    protected readonly IRepository<ParentChildLineStats> _parentChildLineStatsRepository;

    #endregion


    #region Ctor

    public ParentChildLineStatsService(IRepository<ParentChildLineStats> parentChildLineStatsRepository)
    {
        _parentChildLineStatsRepository = parentChildLineStatsRepository;
    }

    #endregion


    #region Methods

    /// <summary>
    /// Get list of parent child line stats by parent id
    /// </summary>
    /// <param name="parentId">ParentId</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the customer
    /// </returns>
    public virtual async Task<List<ParentChildLineStats>> GetParentChildLineStatsListAsync(int parentId)
    {
        var query = from s in _parentChildLineStatsRepository.Table
                    where s.ParentId == parentId
                    orderby s.LineLevel
                    select s;

        return await query.ToListAsync();
    }

    #endregion
}
