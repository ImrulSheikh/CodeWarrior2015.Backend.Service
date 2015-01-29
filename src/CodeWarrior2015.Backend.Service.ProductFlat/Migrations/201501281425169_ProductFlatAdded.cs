using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.Query.Migrations
{
    public partial class ProductFlatAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductFlats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        NumberOfUnits = c.Int(nullable: false),
                        ImagePath = c.String(),
                        Tags = c.String(),
                        Comments = c.String(),
                        Properties = c.String(),
                        Prices = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Category = c.String(),
                        PostedUserId = c.Int(nullable: false),
                        PostedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductFlats");
        }
    }
}
