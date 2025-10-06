using Nop.Core.Domain.Customers;
using Nop.Data;

namespace Nop.Services.ParentChild;

/// <summary>
/// ParentBankDetails service
/// </summary>
public partial class ParentBankDetailsService : IParentBankDetailsService
{
    #region Fields

    protected readonly IRepository<ParentBankDetails> _parentBankDetailsRepository;

    #endregion


    #region Ctor

    public ParentBankDetailsService(IRepository<ParentBankDetails> parentBankDetailsRepository)
    {
        _parentBankDetailsRepository = parentBankDetailsRepository;
    }

    #endregion


    #region Methods

    /// <summary>
    /// Get parent bank details by parent id
    /// </summary>
    /// <param name="parentId">ParentId</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the customer
    /// </returns>
    public virtual async Task<ParentBankDetails> GetParentBankDetailsAsync(int parentId)
    { 
        var query = from p in _parentBankDetailsRepository.Table
                    where p.ParentId == parentId
                    select p;

        return await query.FirstOrDefaultAsync();
    }


    /// <summary>
    /// Insert parent bank details
    /// </summary>
    /// <param name="parentBankDetails">ParentBankDetails</param>
    /// <returns>The inserted Id</returns>
    public virtual async Task<int> InsertParentBankDetailsAsync(ParentBankDetails parentBankDetails)
    { 
        await _parentBankDetailsRepository.InsertAsync(parentBankDetails);
        return parentBankDetails.Id;
    }


    /// <summary>
    /// Update parent bank details
    /// </summary>
    /// <param name="parentBankDetails">ParentBankDetails</param>
    /// <returns>The inserted Id</returns>
    public virtual async Task<int> UpdateParentBankDetailsAsync(ParentBankDetails parentBankDetails)
    {
        await _parentBankDetailsRepository.UpdateAsync(parentBankDetails);
        return parentBankDetails.Id;
    }
    #endregion  
}
