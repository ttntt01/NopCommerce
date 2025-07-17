using Nop.Core.Domain.Customers;
using Nop.Data;

namespace Nop.Services.ParentChild;

/// <summary>
/// ParentChildRelations service
/// </summary>
public partial class ParentChildRelationsService : IParentChildRelationsService
{
    #region Fields

    protected readonly IRepository<ParentChildRelations> _parentChildRelationsRepository;

    #endregion


    #region Ctor

    public ParentChildRelationsService(IRepository<ParentChildRelations> parentChildRelationsRepository)
    {
        _parentChildRelationsRepository = parentChildRelationsRepository;
    }

    #endregion


    #region Methods

    /// <summary>
    /// Check child exist 
    /// </summary>
    /// <param name="childId">ChildId</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the result
    /// </returns>
    public virtual async Task<ParentChildRelations> IsChildExistAsync(int childId)
    {
        var query = from p in _parentChildRelationsRepository.Table
                    where p.ChildId == childId
                    select p;

        var parentChild = query.FirstOrDefault();

        return parentChild;
    }


    /// <summary>
    /// Insert a parent child relationship
    /// </summary>
    /// <param name="parentChildRelations">ParentChildRelations</param>
    /// <returns>The inserted Id</returns>
    public virtual async Task<int> InsertParentChildRelationsAsync(ParentChildRelations parentChildRelations)
    {
        await _parentChildRelationsRepository.InsertAsync(parentChildRelations);
        return parentChildRelations.Id; // entity's Id is updated after insert
    }


    /// <summary>
    /// One parent (line 1) can have multiple children, but a child can only be registered once.
    /// </summary>
    /// <param name="childId">ChildId</param>
    /// <returns>The bool</returns>
    public virtual async Task<bool> IsChildAlreadyRegisteredAsync(int childId)
    {
        return await _parentChildRelationsRepository.Table
        .AnyAsync(r => r.ChildId == childId);
    }


    /// <summary>
    /// Parent (line 1) cannot add another parent (line 1) as a child.
    /// </summary>
    /// <param name="childEmail">ChildEmail</param>
    /// <returns>The bool</returns>
    public virtual async Task<bool> IsChildAlsoAParentAsync(string childEmail)
    {
        return await _parentChildRelationsRepository.Table
            .AnyAsync(r => r.ParentEmail == childEmail);
    }


    /// <summary>
    /// Child (line 2) cannot add parent (line 1) as their child.
    /// </summary>
    /// <param name="childEmail">ChildEmail</param>
    /// <param name="parentEmail ">ParentEmail </param>
    /// <returns>The bool</returns>
    public virtual async Task<bool> IsChildTryingToAddParentAsync(string childEmail, string parentEmail)
    {    
        // Check if acting email is already a child (Line 2)
        var isChild = await _parentChildRelationsRepository.Table
            .AnyAsync(r => r.ChildEmail == childEmail);

        // Check if target is already a parent (Line 1)
        var isTargetParent = await _parentChildRelationsRepository.Table
            .AnyAsync(r => r.ParentEmail == parentEmail);

        return isChild && isTargetParent;
    }

    #endregion
}
