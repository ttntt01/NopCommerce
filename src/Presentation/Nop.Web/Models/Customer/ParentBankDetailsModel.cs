using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Models.Customer;

public partial record ParentBankDetailsModel : BaseNopModel
{
    [NopResourceDisplayName("Account.Comission.Fields.Id")]
    public int Id { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.ParentId")]
    public int ParentId { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.ParentEmail")]
    public string ParentEmail { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.BankName")]
    public string BankName { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.BranchName")]
    public string BranchName { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.BranchAddress")]
    public string BranchAddress { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.AccountHolderName")]
    public string AccountHolderName { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.AccountNumber")]
    public string AccountNumber { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.AccountType")]
    public string AccountType { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.SwiftOrBicCode")]
    public string SwiftOrBicCode { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.CurrencyCode")]
    public string CurrencyCode { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.CreatedDateTimeUtc")]
    public string CreatedDateTimeUtc { get; set; }

    [NopResourceDisplayName("Account.Comission.Fields.LastUpdatedTimeUtc")]
    public string LastUpdatedTimeUtc { get; set; }
}
