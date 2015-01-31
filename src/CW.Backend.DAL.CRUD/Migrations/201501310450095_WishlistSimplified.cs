namespace CW.Backend.DAL.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WishlistSimplified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserWishlists", "ApplicationUserId", "dbo.Users");
            DropIndex("dbo.UserWishlists", new[] { "ApplicationUserId" });
            AddColumn("dbo.UserWishlists", "WishedUserId", c => c.String());
            AddColumn("dbo.UserWishlists", "WishedProductId", c => c.Int(nullable: false));
            DropColumn("dbo.UserWishlists", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserWishlists", "ApplicationUserId", c => c.String(maxLength: 128));
            DropColumn("dbo.UserWishlists", "WishedProductId");
            DropColumn("dbo.UserWishlists", "WishedUserId");
            CreateIndex("dbo.UserWishlists", "ApplicationUserId");
            AddForeignKey("dbo.UserWishlists", "ApplicationUserId", "dbo.Users", "Id");
        }
    }
}
