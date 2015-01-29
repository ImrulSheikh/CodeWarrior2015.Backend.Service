using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.CRUD.Migrations
{
    public partial class ProductAddRelationToUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "User_Id", "dbo.Users");
            DropIndex("dbo.Products", new[] { "User_Id" });
            RenameColumn(table: "dbo.Products", name: "User_Id", newName: "PostedBy");
            AlterColumn("dbo.Products", "PostedBy", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "PostedBy");
            AddForeignKey("dbo.Products", "PostedBy", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PostedBy", "dbo.Users");
            DropIndex("dbo.Products", new[] { "PostedBy" });
            AlterColumn("dbo.Products", "PostedBy", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "PostedBy", newName: "User_Id");
            CreateIndex("dbo.Products", "User_Id");
            AddForeignKey("dbo.Products", "User_Id", "dbo.Users", "Id");
        }
    }
}
