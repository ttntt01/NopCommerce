using DocumentFormat.OpenXml.Office2010.Excel;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Localization;
using Nop.Data;

namespace Nop.Services.Commission;

/// <summary>
/// Commission service
/// </summary>
public partial class CommissionService : ICommissionService
{
    #region Fields

    protected readonly IRepository<ParentChildSumOrderStats> _parentChildSumOrderStatsRepository;
    protected readonly IRepository<LocalizedProperty> _localizedPropertyRepository;
    protected readonly IWorkContext _workContext;

    #endregion

    #region Ctor

    public CommissionService(IRepository<ParentChildSumOrderStats> parentChildSumOrderStatsRepository, IRepository<LocalizedProperty> localizedPropertyRepository, IWorkContext workContext)
    {
        _parentChildSumOrderStatsRepository = parentChildSumOrderStatsRepository;
        _localizedPropertyRepository = localizedPropertyRepository;
        _workContext = workContext;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Search products
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
    public virtual async Task<IPagedList<ParentChildSumOrderStats>> SearchParentChildSumOrderStatsAsync(int year, int month, string parentEmail, 
        bool? isPaid, int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
    {
        //some databases don't support int.MaxValue
        if (pageSize == int.MaxValue)
            pageSize = int.MaxValue - 1;

        var parentChildSumOrderStats = await _parentChildSumOrderStatsRepository.GetAllPagedAsync(query =>
        {
            // Required filter: Year and Month
            query = query.Where(x => x.Year == year && x.Month == month);

            // Optional filter: ParentEmail (LIKE '%parentEmail%')
            if (!string.IsNullOrEmpty(parentEmail))
                query = query.Where(x => x.ParentEmail.Contains(parentEmail));

            // Optional filter: isPaid 
            if (isPaid.HasValue)
                query = query.Where(x => x.IsPaid == isPaid);

            // Sort by Id descending
            query = query.OrderByDescending(x => x.Id);

            return query;
        }, pageIndex, pageSize, getOnlyTotalCount);

        return parentChildSumOrderStats; 
    }


    /// <summary>
    /// Prepare parent child sum order stats model
    /// </summary>
    /// <param name="id">Id search</param>    
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the parent child sum order stats model
    /// </returns>
    public virtual async Task<ParentChildSumOrderStats> PrepareParentChildSumOrderStatsModelAsync(int id)
    { 
        var parentChildSumOrderStats = await _parentChildSumOrderStatsRepository.GetByIdAsync(id);

        return parentChildSumOrderStats;
    }


    /// <summary>
    /// Update commission paid
    /// </summary>
    /// <param name="parentChildSumOrderStats">Parent Child Sum Order Stats identifiers</param>
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// Parameters contains the parent child sum order stats
    /// </returns>
    public virtual async Task<ParentChildSumOrderStats> UpdateIsPaidStatusAsync(ParentChildSumOrderStats parentChildSumOrderStats)
    {
        await _parentChildSumOrderStatsRepository.UpdateAsync(parentChildSumOrderStats);

        var result = await _parentChildSumOrderStatsRepository.GetByIdAsync(parentChildSumOrderStats.Id);

        return result;
    }
    #endregion
}
