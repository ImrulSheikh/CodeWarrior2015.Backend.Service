namespace CW.Backend.DAL.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductOrderM2M : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            RenameColumn(table: "dbo.Products", name: "PostedBy_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Products", name: "IX_PostedBy_Id", newName: "IX_ApplicationUserId");
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Product_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.Products", "ImagePaths", c => c.String());
            DropColumn("dbo.Products", "ImagePath");
            DropColumn("dbo.Products", "PostedUserId");
            DropColumn("dbo.Orders", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "PostedUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            DropForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderProducts", new[] { "Product_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Order_Id" });
            DropColumn("dbo.Products", "ImagePaths");
            DropTable("dbo.OrderProducts");
            RenameIndex(table: "dbo.Products", name: "IX_ApplicationUserId", newName: "IX_PostedBy_Id");
            RenameColumn(table: "dbo.Products", name: "ApplicationUserId", newName: "PostedBy_Id");
            CreateIndex("dbo.Orders", "ProductId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
