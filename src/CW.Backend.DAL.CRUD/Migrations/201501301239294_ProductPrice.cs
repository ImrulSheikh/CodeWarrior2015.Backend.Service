namespace CW.Backend.DAL.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "Discount", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "DiscountValidity", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DiscountValidity");
            DropColumn("dbo.Products", "Discount");
            DropColumn("dbo.Products", "UnitPrice");
        }
    }
}
