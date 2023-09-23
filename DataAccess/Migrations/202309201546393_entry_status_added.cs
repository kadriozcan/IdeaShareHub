namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entry_status_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entries", "Status");
        }
    }
}
