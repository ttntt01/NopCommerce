using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo500;

[NopUpdateMigration("2025-07-07 13:00:00", "5.00", UpdateMigrationType.Data)]
public class DataMigration : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Create.Table("ParentChildOrderStats")
             .WithColumn("Id").AsInt32().Identity()
             .WithColumn("ParentId").AsInt32().NotNullable()
             .WithColumn("ParetnEmail").AsString(1000).NotNullable()
             .WithColumn("Year").AsInt32().NotNullable().WithDefaultValue(0)
             .WithColumn("Month").AsInt32().NotNullable().WithDefaultValue(0)
             .WithColumn("LineLevel").AsInt32().NotNullable()
             .WithColumn("CurrencyCode").AsString(10).NotNullable()
             .WithColumn("TotalOrderAmount").AsDecimal(18, 2).NotNullable().WithDefaultValue(0)
             .WithColumn("TotalOrderCount").AsInt32().NotNullable().WithDefaultValue(0)
             .WithColumn("CreatedDateTimeUtc").AsDateTime().NotNullable()
             .WithColumn("LastUpdatedTimeUtc").AsDateTime().NotNullable();

        Create.PrimaryKey("PK_ParentChildOrderStats")
            .OnTable("ParentChildOrderStats")
            .Columns("ParentId", "LineLevel", "CurrencyCode");
    }

    public override void Down()
    {
    }
}
