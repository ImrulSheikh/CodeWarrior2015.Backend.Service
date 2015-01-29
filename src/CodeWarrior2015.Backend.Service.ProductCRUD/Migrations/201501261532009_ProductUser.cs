using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.CRUD.Migrations
{
    public partial class ProductUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "User_Id", "dbo.Users");
            DropIndex("dbo.Products", new[] { "User_Id" });
            RenameColumn(table: "dbo.Products", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Products", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "UserId");
            AddForeignKey("dbo.Products", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "PostedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PostedBy", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "UserId" });
            AlterColumn("dbo.Products", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Products", "User_Id");
            AddForeignKey("dbo.Products", "User_Id", "dbo.Users", "Id");
        }
    }
}
