using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo500;

[NopUpdateMigration("2025-07-09 13:19:00", "5.001", UpdateMigrationType.Data)]
public class DataMigration1 : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration1(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Alter.Table("ParentChildOrderStats")
            .AddColumn("ExecuteStartDateTime").AsDateTime().NotNullable()
            .AddColumn("ExecuteEndDateTime").AsDateTime().NotNullable();
    }

    public override void Down()
    {

    }
}
