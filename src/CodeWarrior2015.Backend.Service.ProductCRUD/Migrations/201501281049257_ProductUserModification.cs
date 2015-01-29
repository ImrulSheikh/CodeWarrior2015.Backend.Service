using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.CRUD.Migrations
{
    public partial class ProductUserModification : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "PostedBy", newName: "PostedUserId");
            RenameIndex(table: "dbo.Products", name: "IX_PostedBy", newName: "IX_PostedUserId");
            AlterColumn("dbo.Categories", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Categories", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ProductPrices", "DiscountValidity", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductPrices", "DiscountValidity", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedOn", c => c.DateTime(nullable: false));
            RenameIndex(table: "dbo.Products", name: "IX_PostedUserId", newName: "IX_PostedBy");
            RenameColumn(table: "dbo.Products", name: "PostedUserId", newName: "PostedBy");
        }
    }
}
