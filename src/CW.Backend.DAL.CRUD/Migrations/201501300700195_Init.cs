namespace CW.Backend.DAL.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                        ParentId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        NumberOfUnits = c.Int(nullable: false),
                        ImagePath = c.String(),
                        CategoryId = c.Int(nullable: false),
                        PostedUserId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        Status = c.Int(nullable: false),
                        PostedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PostedBy_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.PostedBy_Id);
            
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
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        Status = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.ProductId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FullName = c.String(maxLength: 50),
                        Sex = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                        CreatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
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
                "dbo.ProductPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        DiscountValidity = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            DropForeignKey("dbo.UserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropForeignKey("dbo.CategoryProperties", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductProperties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "PostedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductProductGroups", "ProductGroup_Id", "dbo.ProductGroups");
            DropForeignKey("dbo.ProductProductGroups", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductComments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ProductProductGroups", new[] { "ProductGroup_Id" });
            DropIndex("dbo.ProductProductGroups", new[] { "Product_Id" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.CategoryProperties", new[] { "CategoryId" });
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropIndex("dbo.ProductProperties", new[] { "ProductId" });
            DropIndex("dbo.UserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.ProductComments", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "PostedBy_Id" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropTable("dbo.ProductProductGroups");
            DropTable("dbo.Roles");
            DropTable("dbo.ProductPrices");
            DropTable("dbo.CategoryProperties");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductProperties");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.ProductComments");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
