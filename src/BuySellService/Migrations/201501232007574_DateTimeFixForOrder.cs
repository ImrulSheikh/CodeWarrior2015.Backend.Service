namespace PatientData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFixForOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
