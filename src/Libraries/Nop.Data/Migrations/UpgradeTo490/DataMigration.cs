using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo490;

[NopUpdateMigration("2025-07-04 10:00:00", "4.90", UpdateMigrationType.Data)]
public class DataMigration : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Create.Table("ParentChildLineStats")
                .WithColumn("Id").AsInt32().Identity()
                .WithColumn("ParentId").AsInt32().NotNullable()
                .WithColumn("ParentEmail").AsString(1000).NotNullable()
                .WithColumn("LineLevel").AsInt32().NotNullable()
                .WithColumn("ChildCount").AsInt32().NotNullable()
                .WithColumn("CreatedDateTimeUtc").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedTimeUtc").AsDateTime().NotNullable();

        // Define composite primary key
        Create.PrimaryKey("PK_ParentChildLineStats")
            .OnTable("ParentChildLineStats")
            .Columns("ParentId", "LineLevel");
    }

    public override void Down()
    {
    }
}
