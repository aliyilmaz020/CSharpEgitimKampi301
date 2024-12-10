﻿namespace CSharpEgitimKampi301.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgProductPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductPrice");
        }
    }
}
