using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo550;

[NopUpdateMigration("2026-04-02 17:35:00", "5.500", UpdateMigrationType.Data)]
public class DataMigration : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        //create sp_UpdateParentChildLineStats table
        Create.Table("UpdateParentChildLineStats_ExecutionLog")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("StartExecDateTime").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
             .WithColumn("EndExecDateTime").AsDateTime().Nullable()
             .WithColumn("Status").AsString(10).NotNullable().WithDefaultValue("Success")
             .WithColumn("ErrorMessage").AsString(int.MaxValue).Nullable()
             .WithColumn("ErrorSeverity").AsInt32().Nullable()
             .WithColumn("RowsAffected").AsInt32().Nullable()
             .WithColumn("DurationMs").AsInt32().Nullable()
             .WithColumn("CreatedDateTime").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
             .WithColumn("UpdatedDateTime").AsDateTime().Nullable();

        Create.Index("IX_UpdateParentChildLineStats_ExecutionLog")
            .OnTable("UpdateParentChildLineStats_ExecutionLog")
            .OnColumn("StartExecDateTime").Ascending();


        //create sp_UpdateParentChildOrderStats table
        Create.Table("UpdateParentChildOrderStats_ExecutionLog")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("StartExecDateTime").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
             .WithColumn("EndExecDateTime").AsDateTime().Nullable()
             .WithColumn("Status").AsString(10).NotNullable().WithDefaultValue("Success")
             .WithColumn("ErrorMessage").AsString(int.MaxValue).Nullable()
             .WithColumn("ErrorSeverity").AsInt32().Nullable()
             .WithColumn("RowsAffected").AsInt32().Nullable()
             .WithColumn("DurationMs").AsInt32().Nullable()
             .WithColumn("CreatedDateTime").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
             .WithColumn("UpdatedDateTime").AsDateTime().Nullable();

        Create.Index("IX_UpdateParentChildOrderStats_ExecutionLog")
            .OnTable("UpdateParentChildOrderStats_ExecutionLog")
            .OnColumn("StartExecDateTime").Ascending();


        //create sp_UpdateParentChildOrderStats1 table
        Create.Table("UpdateParentChildOrderStats1_ExecutionLog")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("StartExecDateTime").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
             .WithColumn("EndExecDateTime").AsDateTime().Nullable()
             .WithColumn("Status").AsString(10).NotNullable().WithDefaultValue("Success")
             .WithColumn("ErrorMessage").AsString(int.MaxValue).Nullable()
             .WithColumn("ErrorSeverity").AsInt32().Nullable()
             .WithColumn("RowsAffected").AsInt32().Nullable()
             .WithColumn("DurationMs").AsInt32().Nullable()
             .WithColumn("CreatedDateTime").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
             .WithColumn("UpdatedDateTime").AsDateTime().Nullable();

        Create.Index("IX_UpdateParentChildOrderStats1_ExecutionLog")
            .OnTable("UpdateParentChildOrderStats1_ExecutionLog")
            .OnColumn("StartExecDateTime").Ascending();


        //create sp_FinalizeParentPayAmount table
        Create.Table("FinalizeParentPayAmount_ExecutionLog")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("StartExecDateTime").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
             .WithColumn("EndExecDateTime").AsDateTime().Nullable()
             .WithColumn("Status").AsString(10).NotNullable().WithDefaultValue("Success")
             .WithColumn("ErrorMessage").AsString(int.MaxValue).Nullable()
             .WithColumn("ErrorSeverity").AsInt32().Nullable()
             .WithColumn("RowsAffected").AsInt32().Nullable()
             .WithColumn("DurationMs").AsInt32().Nullable()
             .WithColumn("CreatedDateTime").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
             .WithColumn("UpdatedDateTime").AsDateTime().Nullable();

        Create.Index("IX_FinalizeParentPayAmount_ExecutionLog")
            .OnTable("FinalizeParentPayAmount_ExecutionLog")
            .OnColumn("StartExecDateTime").Ascending();
    }

    public override void Down()
    {
        Delete.Table("UpdateParentChildLineStats_ExecutionLog");
        Delete.Table("UpdateParentChildOrderStats_ExecutionLog");
        Delete.Table("UpdateParentChildOrderStats1_ExecutionLog");
        Delete.Table("FinalizeParentPayAmount_ExecutionLog");
    }
}