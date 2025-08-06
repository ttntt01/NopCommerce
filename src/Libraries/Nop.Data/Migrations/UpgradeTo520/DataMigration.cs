using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo520;

[NopUpdateMigration("2025-08-06 13:18:00", "5.20", UpdateMigrationType.Data)]
public class DataMigration : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        // Create ProductFile table
        Create.Table("ProductFile")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("ProductId").AsInt32().NotNullable()
            .WithColumn("MimeType").AsString(40).NotNullable()
            .WithColumn("SeoFilename").AsString(300).Nullable()
            .WithColumn("AltAttribute").AsString(int.MaxValue).Nullable()
            .WithColumn("TitleAttribute").AsString(int.MaxValue).Nullable()
            .WithColumn("IsNew").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("VirtualPath").AsString(int.MaxValue).Nullable()
            .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("CreatedDateTimeUTC").AsDateTime().NotNullable()
            .WithColumn("UpdatedDateTimeUTC").AsDateTime().Nullable();

        // Create FileBinary table
        Create.Table("FileBinary")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("FileId").AsInt32().NotNullable()
            .WithColumn("BinaryData").AsBinary(int.MaxValue).Nullable();

        // Foreign key: ProductFile.ProductId → Product.Id
        Create.ForeignKey("FK_ProductFile_Product")
            .FromTable("ProductFile").ForeignColumn("ProductId")
            .ToTable("Product").PrimaryColumn("Id");

        // Foreign key: FileBinary.FileId → ProductFile.Id
        Create.ForeignKey("FK_FileBinary_ProductFile")
            .FromTable("FileBinary").ForeignColumn("FileId")
            .ToTable("ProductFile").PrimaryColumn("Id");
    }

    public override void Down()
    {
    }
}
