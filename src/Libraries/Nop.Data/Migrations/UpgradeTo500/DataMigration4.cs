using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo500;

[NopUpdateMigration("2025-07-13 13:19:00", "5.004", UpdateMigrationType.Data)]
public class DataMigration4 : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration4(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Alter.Table("ParentChildOrderStats1")
            .AddColumn("CommissionRate").AsString().NotNullable()
            .AddColumn("PayAmount").AsDecimal(18, 2).NotNullable();
    }

    public override void Down()
    {
    }
}
