using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo500;

[NopUpdateMigration("2025-07-11 13:19:00", "5.003", UpdateMigrationType.Data)]
public class DataMigration3 : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration3(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Rename.Column("ParetnEmail").OnTable("ParentChildOrderStats1").To("ParentEmail");  
    }

    public override void Down()
    {
    }
}
