namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class topicstatusadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topics", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Topics", "Status");
        }
    }
}
