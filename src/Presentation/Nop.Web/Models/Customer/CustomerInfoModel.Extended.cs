using Nop.Core.Domain.Customers;

namespace Nop.Web.Models.Customer;

public partial record CustomerInfoModel
{
    public List<ParentChildLineStats> ParentChildLineStatsModel { get; set; } = new();

    public ParentChildSumOrderStats ParentChildSumOrderStatsModel { get; set; }

    public ParentBankDetailsModel ParentBankDetailsModel { get; set; }
}
