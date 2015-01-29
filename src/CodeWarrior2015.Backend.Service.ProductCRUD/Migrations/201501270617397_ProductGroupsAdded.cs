using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.CRUD.Migrations
{
    public partial class ProductGroupsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductProductGroups",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        ProductGroup_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.ProductGroup_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroup_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductGroup_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductProductGroups", "ProductGroup_Id", "dbo.ProductGroups");
            DropForeignKey("dbo.ProductProductGroups", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductProductGroups", new[] { "ProductGroup_Id" });
            DropIndex("dbo.ProductProductGroups", new[] { "Product_Id" });
            DropTable("dbo.ProductProductGroups");
            DropTable("dbo.ProductGroups");
        }
    }
}
