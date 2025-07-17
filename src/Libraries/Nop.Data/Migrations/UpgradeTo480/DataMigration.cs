using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo480;

[NopUpdateMigration("2025-06-11 18:00:00", "4.80", UpdateMigrationType.Data)]
public class DataMigration : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Create.Table("ParentChildRelations")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ParentId").AsInt32().NotNullable()
                .WithColumn("ParentEmail").AsString(1000).NotNullable()
                .WithColumn("ChildId").AsInt32().NotNullable()
                .WithColumn("ChildEmail").AsString(1000).NotNullable()
                .WithColumn("CreatedDateTimeUtc").AsDateTime().NotNullable();

        //var parentChildRelations = NameCompatibilityManager.GetTableName(typeof(ParentChildRelations));

        //if (!Schema.Table(parentChildRelations).Column(nameof(ParentChildRelations.Id)).Exists())
        //    Alter.Table(parentChildRelations)
        //        .AddColumn(nameof(ParentChildRelations.Id)).AsInt32().PrimaryKey().Identity();

        //if (!Schema.Table(parentChildRelations).Column(nameof(ParentChildRelations.ParentId)).Exists())
        //    Alter.Table(parentChildRelations)
        //        .AddColumn(nameof(ParentChildRelations.ParentId)).AsInt32().NotNullable();

        //if (!Schema.Table(parentChildRelations).Column(nameof(ParentChildRelations.ParentEmail)).Exists())
        //    Alter.Table(parentChildRelations)
        //        .AddColumn(nameof(ParentChildRelations.ParentEmail)).AsString(1000).NotNullable();

        //if (!Schema.Table(parentChildRelations).Column(nameof(ParentChildRelations.ChildId)).Exists())
        //    Alter.Table(parentChildRelations)
        //        .AddColumn(nameof(ParentChildRelations.ChildId)).AsInt32().NotNullable();

        //if (!Schema.Table(parentChildRelations).Column(nameof(ParentChildRelations.ChildEmail)).Exists())
        //    Alter.Table(parentChildRelations)
        //        .AddColumn(nameof(ParentChildRelations.ChildEmail)).AsString(1000).NotNullable();

        //if (!Schema.Table(parentChildRelations).Column(nameof(ParentChildRelations.CreatedDateTimeUtc)).Exists())
        //    Alter.Table(parentChildRelations)
        //        .AddColumn(nameof(ParentChildRelations.CreatedDateTimeUtc)).AsDateTime().NotNullable();
    }

    public override void Down()
    {
    }
}
