namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conternt_entry : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contents", newName: "Entries");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Entries", newName: "Contents");
        }
    }
}
