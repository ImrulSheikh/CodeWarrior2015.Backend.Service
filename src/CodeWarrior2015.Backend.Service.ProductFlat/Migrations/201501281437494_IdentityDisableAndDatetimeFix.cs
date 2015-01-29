namespace CodeWarrior2015.Backend.Service.ProductFlat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityDisableAndDatetimeFix : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductFlats");
            AddColumn("dbo.ProductFlats", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.ProductFlats", "CreatedBy", c => c.String());
            AddColumn("dbo.ProductFlats", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.ProductFlats", "UpdatedBy", c => c.String());
            AddColumn("dbo.ProductFlats", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductFlats", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductFlats", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProductFlats");
            AlterColumn("dbo.ProductFlats", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.ProductFlats", "Status");
            DropColumn("dbo.ProductFlats", "UpdatedBy");
            DropColumn("dbo.ProductFlats", "UpdatedOn");
            DropColumn("dbo.ProductFlats", "CreatedBy");
            DropColumn("dbo.ProductFlats", "CreatedOn");
            AddPrimaryKey("dbo.ProductFlats", "Id");
        }
    }
}
