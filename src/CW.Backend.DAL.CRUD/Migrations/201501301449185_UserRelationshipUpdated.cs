namespace CW.Backend.DAL.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRelationshipUpdated : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Orders", name: "IX_User_Id", newName: "IX_ApplicationUserId");
            AddColumn("dbo.ProductComments", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProductComments", "ApplicationUserId");
            AddForeignKey("dbo.ProductComments", "ApplicationUserId", "dbo.Users", "Id");
            DropColumn("dbo.Orders", "OrderedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderedBy", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductComments", "ApplicationUserId", "dbo.Users");
            DropIndex("dbo.ProductComments", new[] { "ApplicationUserId" });
            DropColumn("dbo.ProductComments", "ApplicationUserId");
            RenameIndex(table: "dbo.Orders", name: "IX_ApplicationUserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Orders", name: "ApplicationUserId", newName: "User_Id");
        }
    }
}
