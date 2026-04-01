using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Models.Customer;

public partial record ParentBankDetailsModel : BaseNopModel
{
    [NopResourceDisplayName("Account.Commission.Fields.Id")]
    public int Id { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.ParentId")]
    public int ParentId { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.ParentEmail")]
    public string ParentEmail { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.BankName")]
    public string BankName { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.BranchName")]
    public string BranchName { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.BranchAddress")]
    public string BranchAddress { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.AccountHolderName")]
    public string AccountHolderName { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.AccountNumber")]
    public string AccountNumber { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.AccountType")]
    public string AccountType { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.SwiftOrBicCode")]
    public string SwiftOrBicCode { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.CurrencyCode")]
    public string CurrencyCode { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.CreatedDateTimeUtc")]
    public string CreatedDateTimeUtc { get; set; }

    [NopResourceDisplayName("Account.Commission.Fields.LastUpdatedTimeUtc")]
    public string LastUpdatedTimeUtc { get; set; }

    public string ModelUsername { get; set; }   
}
