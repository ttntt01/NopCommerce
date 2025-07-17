using Nop.Core.Domain.Customers;
using Nop.Data;

namespace Nop.Services.ParentChild;

public partial class ParentChildSumOrderStatsService : IParentChildSumOrderStatsService
{
    #region Fields

    protected readonly IRepository<ParentChildSumOrderStats> _parentChildSumOrderStatsRepository;

    #endregion


    #region Ctor

    public ParentChildSumOrderStatsService(IRepository<ParentChildSumOrderStats> parentChildSumOrderStatsRepository)
    {
        _parentChildSumOrderStatsRepository = parentChildSumOrderStatsRepository;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get parent child sum order stats by parent id
    /// </summary>
    /// <param name="parentId">ParentId</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the customer
    /// </returns>
    public virtual async Task<ParentChildSumOrderStats> GetParentChildSumOrderStatsAsync(int parentId, int year, int month)
    {
        var query = from s in _parentChildSumOrderStatsRepository.Table
                    where s.ParentId == parentId && s.Month == month && s.Year == year             
                    select s;

        return await query.FirstOrDefaultAsync();
    }

    #endregion
}
