using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo510;

[NopUpdateMigration("2025-07-14 13:19:00", "5.103", UpdateMigrationType.Data)]
public class DataMigration3 : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration3(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Alter.Table("ParentChildSumOrderStats")
            .AddColumn("PayAmount").AsDecimal(18, 2).NotNullable();
    }

    public override void Down()
    {

    }
}
