namespace PatientData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagCommentOrderIdentityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsMandatory = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
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
                "dbo.ProductGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        DiscountValidity = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Value = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Sex = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductGroupProducts",
                c => new
                    {
                        ProductGroup_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductGroup_Id, t.Product_Id })
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroup_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.ProductGroup_Id)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.Orders", "TotalPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Orders", "OrderedBy", c => c.String());
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "User_Id", c => c.Int());
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "NumberOfUnits", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            AddColumn("dbo.Products", "PostedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.Orders", "ProductId");
            CreateIndex("dbo.Orders", "User_Id");
            CreateIndex("dbo.Products", "UserId");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Products", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.Products", "Category");
            DropColumn("dbo.Products", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Category", c => c.String());
            AddColumn("dbo.Orders", "UserId", c => c.String());
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductProperties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductGroupProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductGroupProducts", "ProductGroup_Id", "dbo.ProductGroups");
            DropForeignKey("dbo.ProductComments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CategoryProperties", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropIndex("dbo.ProductProperties", new[] { "ProductId" });
            DropIndex("dbo.ProductPrices", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.ProductGroupProducts", new[] { "Product_Id" });
            DropIndex("dbo.ProductGroupProducts", new[] { "ProductGroup_Id" });
            DropIndex("dbo.ProductComments", new[] { "ProductId" });
            DropIndex("dbo.CategoryProperties", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Products", "Category_Id");
            DropColumn("dbo.Products", "Status");
            DropColumn("dbo.Products", "UserId");
            DropColumn("dbo.Products", "PostedBy");
            DropColumn("dbo.Products", "ImagePath");
            DropColumn("dbo.Products", "NumberOfUnits");
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Orders", "User_Id");
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "OrderedBy");
            DropColumn("dbo.Orders", "TotalPrice");
            DropTable("dbo.ProductGroupProducts");
            DropTable("dbo.Users");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductProperties");
            DropTable("dbo.ProductPrices");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.ProductComments");
            DropTable("dbo.CategoryProperties");
            DropTable("dbo.Categories");
        }
    }
}
