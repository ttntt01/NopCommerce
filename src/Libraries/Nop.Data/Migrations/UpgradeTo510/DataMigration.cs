using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo510;

[NopUpdateMigration("2025-07-07 13:18:00", "5.10", UpdateMigrationType.Data)]
public class DataMigration : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Create.Table("ParentChildSumOrderStats")
            .WithColumn("Id").AsInt32().Identity()
            .WithColumn("ParentId").AsInt32().NotNullable()
            .WithColumn("ParentEmail").AsString(1000).NotNullable()
            .WithColumn("Year").AsInt32().NotNullable().WithDefaultValue(0)
            .WithColumn("Month").AsInt32().NotNullable().WithDefaultValue(0)
            .WithColumn("CurrencyCode").AsString(10).NotNullable()
            .WithColumn("CurrencyRate").AsDecimal(18, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("TotalOrderAmount").AsDecimal(18, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("TotalOrderCount").AsInt32().NotNullable().WithDefaultValue(0)
            .WithColumn("CreatedDateTimeUtc").AsDateTime().NotNullable()
            .WithColumn("LastUpdatedTimeUtc").AsDateTime().NotNullable()
            .WithColumn("IsPaid").AsBoolean().NotNullable().WithDefaultValue(false);

        Create.PrimaryKey("PK_ParentChildSumOrderStats")
            .OnTable("ParentChildSumOrderStats")
            .Columns("ParentId", "Year", "Month", "CurrencyCode");
    }

    public override void Down()
    {
    }
}
