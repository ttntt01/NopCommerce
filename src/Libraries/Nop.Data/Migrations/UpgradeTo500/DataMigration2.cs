using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo500;

[NopUpdateMigration("2025-07-10 13:19:00", "5.002", UpdateMigrationType.Data)]
public class DataMigration2 : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration2(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Create.Table("ParentChildOrderStats1")
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
             .WithColumn("LastUpdatedTimeUtc").AsDateTime().NotNullable()
             .WithColumn("ExecuteStartDateTime").AsDateTime().NotNullable()
             .WithColumn("ExecuteEndDateTime").AsDateTime().NotNullable();

        Create.PrimaryKey("PK_ParentChildOrderStats1")
            .OnTable("ParentChildOrderStats1")
            .Columns("ParentId", "LineLevel", "CurrencyCode");
    }

    public override void Down()
    {
    }
}
