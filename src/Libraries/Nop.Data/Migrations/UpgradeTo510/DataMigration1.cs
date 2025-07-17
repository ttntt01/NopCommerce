using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo510;

[NopUpdateMigration("2025-07-08 13:19:00", "5.101", UpdateMigrationType.Data)]
public class DataMigration1 : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration1(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Alter.Table("ParentChildSumOrderStats")
            .AddColumn("IsPaid").AsBoolean().NotNullable().WithDefaultValue(false);
    }

    public override void Down()
    {

    }
}
