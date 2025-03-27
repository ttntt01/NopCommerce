using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Customers;

/// <summary>
/// Represents a customer agent entity builder
/// </summary>
public partial class CustomerAgentBuilder : NopEntityBuilder<CustomerAgent>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(CustomerAgent.AgentId)).AsInt32().NotNullable();
        table.WithColumn(nameof(CustomerAgent.AgentUsername)).AsString(1000).NotNullable();
        table.WithColumn(nameof(CustomerAgent.CustomerId)).AsInt32().NotNullable().ForeignKey<Customer>();
        table.WithColumn(nameof(CustomerAgent.CustomerUsername)).AsString(1000).NotNullable();
        table.WithColumn(nameof(CustomerAgent.CreatedDateTime)).AsDateTime().NotNullable();
    }

    #endregion
}
