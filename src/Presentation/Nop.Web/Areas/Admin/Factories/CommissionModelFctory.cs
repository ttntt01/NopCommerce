using Nop.Web.Areas.Admin.Models.Commission;
using Nop.Web.Framework.Models.Extensions;
using Nop.Services.Commission;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;

namespace Nop.Web.Areas.Admin.Factories;

public partial class CommissionModelFctory : ICommissionModelFctory
{
    #region Fields

    protected readonly ICommissionService _commissionService;

    #endregion


    #region Ctor

    public CommissionModelFctory(ICommissionService commissionService) 
    {
        _commissionService = commissionService;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Prepare commission search model
    /// </summary>
    /// <param name="searchModel">Commission search model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the commission search model
    /// </returns>
    public virtual Task<CommissionSearchModel> PrepareCommissionSearchModelAsync(CommissionSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(searchModel);

        //prepare page parameters
        searchModel.SetGridPageSize();

        return Task.FromResult(searchModel);
    }

    /// Prepare paged parent child sum order stats list model
    /// </summary>
    /// <param name="searchModel">ParentChildSumOrderStats search model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the parent child sum order stats list model
    /// </returns>
    public virtual async Task<ParentChildSumOrderStatsListModel> PrepareParentChildSumOrderStatsListModelAsync(CommissionSearchModel searchModel)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            var isPaid = searchModel.SelectedIsPaid == null ? null : (searchModel.SelectedIsPaid == 1 ? true : (bool?)false);

            ////get parent child sum order stats
            var parentChildSumOrdersStats = await _commissionService.SearchParentChildSumOrderStatsAsync(searchModel.Year, searchModel.Month, searchModel.ParentEmail, isPaid);

            ////prepare list model
            var model = await new ParentChildSumOrderStatsListModel().PrepareToGridAsync(searchModel, parentChildSumOrdersStats, () =>
            {
                return parentChildSumOrdersStats.SelectAwait(async parentChildSumOrderStats =>
                {
                    //fill in model values from the entity
                    var parentChildSumOrderStatsModel = parentChildSumOrderStats.ToModel<ParentChildSumOrderStatsModel>();

                    return parentChildSumOrderStatsModel;
                });
            });

            //var model = new ParentChildSumOrderStatsListModel();
            //var data = new List<ParentChildSumOrderStatsModel>();
            //if (parentChildSumOrderStats != null)
            //{
            //    foreach (var item in parentChildSumOrderStats)
            //    {
            //        var parentChildSumOrderStatsModel = new ParentChildSumOrderStatsModel();
            //        parentChildSumOrderStatsModel.Id = item.Id;
            //        parentChildSumOrderStatsModel.ParentId = item.ParentId;
            //        parentChildSumOrderStatsModel.Year = item.Year;
            //        parentChildSumOrderStatsModel.Month = item.Month;
            //        parentChildSumOrderStatsModel.CurrencyCode = item.CurrencyCode;
            //        parentChildSumOrderStatsModel.CurrencyRate = item.CurrencyRate;
            //        parentChildSumOrderStatsModel.TotalOrderAmount = item.TotalOrderAmount;
            //        parentChildSumOrderStatsModel.TotalOrderCount = item.TotalOrderCount;
            //        parentChildSumOrderStatsModel.CreatedDateTimeUtc = item.CreatedDateTimeUtc;
            //        parentChildSumOrderStatsModel.LastUpdatedTimeUtc = item.LastUpdatedTimeUtc;
            //        parentChildSumOrderStatsModel.IsPaid = item.IsPaid;
            //        parentChildSumOrderStatsModel.PayAmount = item.PayAmount;
            //        parentChildSumOrderStatsModel.ExecuteStartDateTime = item.ExecuteStartDateTime;
            //        parentChildSumOrderStatsModel.ExecuteEndDateTime = item.ExecuteEndDateTime;

            //        data.Add(parentChildSumOrderStatsModel);
            //    }
            //}

            //model.Data = data;
            return model;
        }
        catch (Exception ex)
        {
            return new ParentChildSumOrderStatsListModel();
        }
    }

    #endregion
}
