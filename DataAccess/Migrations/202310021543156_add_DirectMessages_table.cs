﻿namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_DirectMessages_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DirectMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DirectMessages");
        }
    }
}
