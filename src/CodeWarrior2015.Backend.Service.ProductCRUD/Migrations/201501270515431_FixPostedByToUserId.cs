using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.CRUD.Migrations
{
    public partial class FixPostedByToUserId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "PostedBy");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_PostedBy");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_PostedBy", newName: "IX_CategoryId");
            RenameColumn(table: "dbo.Products", name: "PostedBy", newName: "CategoryId");
        }
    }
}
