using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo540;

[NopUpdateMigration("2026-03-21 13:35:00", "5.101", UpdateMigrationType.Data)]
public class DataMigration : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Alter.Table("ParentChildLineStats")
            .AddColumn("Email").AsString().Nullable();
    }

    public override void Down()
    {

    }
}
