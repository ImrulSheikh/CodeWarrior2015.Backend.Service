namespace CW.Backend.DAL.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryPropertyAvailableValuesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CPAvailableValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryPropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryProperties", t => t.CategoryPropertyId, cascadeDelete: true)
                .Index(t => t.CategoryPropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CPAvailableValues", "CategoryPropertyId", "dbo.CategoryProperties");
            DropIndex("dbo.CPAvailableValues", new[] { "CategoryPropertyId" });
            DropTable("dbo.CPAvailableValues");
        }
    }
}
