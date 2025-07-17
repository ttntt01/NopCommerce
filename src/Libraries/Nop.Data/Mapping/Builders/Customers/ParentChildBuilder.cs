using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Builders.Customers;

/// <summary>
/// Represents a parent child relationship entity builsder
/// </summary>
public partial class ParentChildBuilder : NopEntityBuilder<ParentChildRelations>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        //table
        //    .WithColumn(nameof(ParentChildRelations.Id)).AsInt32().Identity()
        //    .WithColumn(nameof(ParentChildRelations.ParentId)).AsInt32().NotNullable()
        //    .WithColumn(nameof(ParentChildRelations.ParentEmail)).AsString(1000).NotNullable()
        //    .WithColumn(nameof(ParentChildRelations.ChildId)).AsInt32().NotNullable()
        //    .WithColumn(nameof(ParentChildRelations.ChildEmail)).AsString(1000).NotNullable()
        //    .WithColumn(nameof(ParentChildRelations.CreatedDateTimeUtc)).AsDateTime().NotNullable();
    }

    #endregion
}
