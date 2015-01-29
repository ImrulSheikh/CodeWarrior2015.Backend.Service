using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.CRUD.Migrations
{
    public partial class CategoryPropertiesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsRequired = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryProperties", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CategoryProperties", new[] { "CategoryId" });
            DropTable("dbo.CategoryProperties");
        }
    }
}
