using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Builders.Customers;

/// <summary>
/// Represents a parent child line entity builder
/// </summary>
public partial class ParentChildLineBuilder : NopEntityBuilder<ParentChildLineStats>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
    }

    #endregion
}
