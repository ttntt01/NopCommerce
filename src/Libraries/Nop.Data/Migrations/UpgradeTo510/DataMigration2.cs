using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo510;

[NopUpdateMigration("2025-07-12 13:19:00", "5.102", UpdateMigrationType.Data)]
public class DataMigration2 : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration2(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Rename.Column("ParetnEmail").OnTable("ParentChildOrderStats").To("ParentEmail");
    }

    public override void Down()
    {

    }
}
