namespace PatientData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
