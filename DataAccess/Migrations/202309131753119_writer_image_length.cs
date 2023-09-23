﻿namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writer_image_length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "Image", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "Image", c => c.String(maxLength: 100));
        }
    }
}
