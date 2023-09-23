namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryidremove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Category_Id", c => c.Int(nullable: false));
        }
    }
}
