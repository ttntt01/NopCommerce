using Nop.Core.Domain.Customers;

namespace Nop.Services.ParentChild;

/// <summary>
/// ParentChildRelations service interface
/// </summary>
public partial interface IParentChildRelationsService
{    
    /// <summary>
     /// Check child exist 
     /// </summary>
     /// <param name="childId">ChildId</param>
     /// <returns>
     /// A task that represents the asynchronous operation
     /// The task result contains the customer
     /// </returns>
    Task<ParentChildRelations> IsChildExistAsync(int childId);


    /// <summary>
    /// Insert a parent child relationship
    /// </summary>
    /// <param name="parentChildRelations">ParentChildRelations</param>
    /// <returns>The inserted Id</returns>
    Task<int> InsertParentChildRelationsAsync(ParentChildRelations parentChildRelations);


    /// <summary>
    /// One parent (line 1) can have multiple children, but a child can only be registered once.
    /// </summary>
    /// <param name="childId">ChildId</param>
    /// <returns>The bool</returns>
    Task<bool> IsChildAlreadyRegisteredAsync(int childId);


    /// <summary>
    /// Parent (line 1) cannot add another parent (line 1) as a child.
    /// </summary>
    /// <param name="childEmail">ChildEmail</param>
    /// <returns>The bool</returns>
    Task<bool> IsChildAlsoAParentAsync(string childEmail);


    /// <summary>
    /// Child (line 2) cannot add parent (line 1) as their child.
    /// </summary>
    /// <param name="childEmail">ChildEmail</param>
    /// <param name="parentEmail ">ParentEmail </param>
    /// <returns>The bool</returns>
    Task<bool> IsChildTryingToAddParentAsync(string childEmail, string parentEmail);
}
