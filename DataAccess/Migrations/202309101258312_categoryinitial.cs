namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryinitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Writers", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.Writers", new[] { "Category_Id1" });
            DropColumn("dbo.Writers", "Category_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Category_Id1", c => c.Int());
            CreateIndex("dbo.Writers", "Category_Id1");
            AddForeignKey("dbo.Writers", "Category_Id1", "dbo.Categories", "Id");
        }
    }
}
