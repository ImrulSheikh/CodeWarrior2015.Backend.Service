using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.CRUD.Migrations
{
    public partial class ProductUserAndCategoryFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "PostedBy", "dbo.Categories");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "PostedBy" });
            DropIndex("dbo.Products", new[] { "UserId" });
            RenameColumn(table: "dbo.Products", name: "PostedBy", newName: "Category_Id");
            RenameColumn(table: "dbo.Products", name: "UserId", newName: "User_Id");
            AlterColumn("dbo.Products", "Category_Id", c => c.Int());
            AlterColumn("dbo.Products", "User_Id", c => c.Int());
            CreateIndex("dbo.Products", "User_Id");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Products", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Products", new[] { "User_Id" });
            AlterColumn("dbo.Products", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "PostedBy");
            CreateIndex("dbo.Products", "UserId");
            CreateIndex("dbo.Products", "PostedBy");
            AddForeignKey("dbo.Products", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "PostedBy", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
