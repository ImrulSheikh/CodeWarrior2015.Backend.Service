using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.CRUD.Migrations
{
    public partial class TagCommentOrderIdentityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        StarRating = c.Int(nullable: false),
                        HelpfulHits = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        OrderedBy = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OrderedBy)
                .Index(t => t.OrderedBy)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TagType = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Products", "NumberOfUnits", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            AddColumn("dbo.CategoryProperties", "IsMandatory", c => c.Boolean(nullable: false));
            DropColumn("dbo.CategoryProperties", "IsRequired");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryProperties", "IsRequired", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "OrderedBy", "dbo.Users");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductComments", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "OrderedBy" });
            DropIndex("dbo.ProductComments", new[] { "ProductId" });
            DropColumn("dbo.CategoryProperties", "IsMandatory");
            DropColumn("dbo.Products", "ImagePath");
            DropColumn("dbo.Products", "NumberOfUnits");
            DropTable("dbo.ProductTags");
            DropTable("dbo.Orders");
            DropTable("dbo.ProductComments");
        }
    }
}
