using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations;

[NopSchemaMigration("2025-03-27 16:24:00", "Create CustomerAgent Table")]
public class CreateCustomerAgentTable : ForwardOnlyMigration
{    
    /// <summary>
     /// Collect the UP migration expressions
     /// </summary>
    public override void Up()
    {
        Create.TableFor<CustomerAgent>();
    }
}
