using FluentMigrator;

namespace Nop.Data.Migrations.UpgradeTo540;

[NopUpdateMigration("2026-03-21 13:49:00", "5.102", UpdateMigrationType.Data)]
public class DataMigration2 : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigration2(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override void Up()
    {
        //------------------------------------------------
        // 1. Add Email column ONLY IF NOT EXISTS
        //------------------------------------------------
        Execute.Sql(@"
            IF COL_LENGTH('ParentChildLineStats', 'Email') IS NULL
            BEGIN
                ALTER TABLE ParentChildLineStats
                ADD Email NVARCHAR(255) NULL;
            END
        ");

        //------------------------------------------------
        // 2. Backfill existing data
        //------------------------------------------------
        Execute.Sql(@"
            UPDATE ParentChildLineStats
            SET Email = ParentEmail
            WHERE Email IS NULL;
        ");

        //------------------------------------------------
        // 3. Drop existing Primary Key (if exists)
        //------------------------------------------------
        Execute.Sql(@"
            IF EXISTS (
                SELECT 1 
                FROM sys.key_constraints 
                WHERE name = 'PK_ParentChildLineStats'
            )
            BEGIN
                ALTER TABLE ParentChildLineStats
                DROP CONSTRAINT PK_ParentChildLineStats;
            END
        ");

        //------------------------------------------------
        // 4. Make Email NOT NULL
        //------------------------------------------------
        Execute.Sql(@"
            ALTER TABLE ParentChildLineStats
            ALTER COLUMN Email NVARCHAR(255) NOT NULL;
        ");

        //------------------------------------------------
        // 5. Recreate PK with Email
        //------------------------------------------------
        Execute.Sql(@"
            ALTER TABLE ParentChildLineStats
            ADD CONSTRAINT PK_ParentChildLineStats
            PRIMARY KEY (ParentId, LineLevel, Email);
        ");
    }

    public override void Down()
    {
        //------------------------------------------------
        // Reverse safely
        //------------------------------------------------

        Execute.Sql(@"
            IF EXISTS (
                SELECT 1 
                FROM sys.key_constraints 
                WHERE name = 'PK_ParentChildLineStats'
            )
            BEGIN
                ALTER TABLE ParentChildLineStats
                DROP CONSTRAINT PK_ParentChildLineStats;
            END
        ");

        Execute.Sql(@"
            ALTER TABLE ParentChildLineStats
            ADD CONSTRAINT PK_ParentChildLineStats
            PRIMARY KEY (ParentId, LineLevel);
        ");

        Execute.Sql(@"
            IF COL_LENGTH('ParentChildLineStats', 'Email') IS NOT NULL
            BEGIN
                ALTER TABLE ParentChildLineStats
                DROP COLUMN Email;
            END
        ");
    }
}
