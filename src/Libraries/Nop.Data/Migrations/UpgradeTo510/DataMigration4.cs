using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo510;

[NopUpdateMigration("2025-07-15 13:19:00", "5.104", UpdateMigrationType.Data)]
public class DataMigration4 : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration4(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Alter.Table("ParentChildSumOrderStats")
            .AddColumn("ExecuteStartDateTime").AsDateTime().NotNullable()
            .AddColumn("ExecuteEndDateTime").AsDateTime().NotNullable();
    }

    public override void Down()
    {

    }
}
