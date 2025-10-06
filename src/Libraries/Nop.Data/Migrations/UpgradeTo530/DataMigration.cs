using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo530;

[NopUpdateMigration("2025-07-08 11:12:00", "5.30", UpdateMigrationType.Data)]
public class DataMigration : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        Create.Table("ParentBankDetails")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("ParentId").AsInt32().NotNullable()
            .WithColumn("ParentEmail").AsString(1000).NotNullable()
            .WithColumn("BankName").AsString(255).NotNullable()
            .WithColumn("BranchName").AsString(255).Nullable()
            .WithColumn("BranchAddress").AsString(1000).Nullable()
            .WithColumn("AccountHolderName").AsString(500).NotNullable()
            .WithColumn("AccountNumber").AsString(100).NotNullable()
            .WithColumn("AccountType").AsString(50).Nullable()
            .WithColumn("SwiftOrBicCode").AsString(20).NotNullable()
            .WithColumn("CurrencyCode").AsString(10).NotNullable()
            .WithColumn("CreatedDateTimeUtc").AsDateTime().NotNullable()
            .WithColumn("LastUpdatedTimeUtc").AsDateTime().Nullable();

        // Optional: Foreign key to Parent table if exists
        // Create.ForeignKey("FK_ParentBankDetails")
        //     .FromTable("ParentBankDetails").ForeignColumn("ParentId")
        //     .ToTable("Parent").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.Table("ParentBankDetails");
    }
}
