using Nop.Core.Domain.Customers;

namespace Nop.Services.ParentChild;

public partial interface IParentBankDetailsService
{    
    /// <summary>
    /// Get parent bank details by parent id
    /// </summary>
    /// <param name="parentId">ParentId</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the customer
    /// </returns>
    Task<ParentBankDetails> GetParentBankDetailsAsync(int parentId);


    /// <summary>
    /// Insert parent bank details
    /// </summary>
    /// <param name="parentBankDetails">ParentBankDetails</param>
    /// <returns>The inserted Id</returns>
    Task<int> InsertParentBankDetailsAsync(ParentBankDetails parentBankDetails);


    /// <summary>
    /// Update parent bank details
    /// </summary>
    /// <param name="parentBankDetails">ParentBankDetails</param>
    /// <returns>The inserted Id</returns>
    Task<int> UpdateParentBankDetailsAsync(ParentBankDetails parentBankDetails);
}
