namespace CW.Backend.DAL.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserWishListAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserWishlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            AddColumn("dbo.Products", "UserWishlistId", c => c.Int());
            CreateIndex("dbo.Products", "UserWishlistId");
            AddForeignKey("dbo.Products", "UserWishlistId", "dbo.UserWishlists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UserWishlistId", "dbo.UserWishlists");
            DropForeignKey("dbo.UserWishlists", "ApplicationUserId", "dbo.Users");
            DropIndex("dbo.UserWishlists", new[] { "ApplicationUserId" });
            DropIndex("dbo.Products", new[] { "UserWishlistId" });
            DropColumn("dbo.Products", "UserWishlistId");
            DropTable("dbo.UserWishlists");
        }
    }
}
