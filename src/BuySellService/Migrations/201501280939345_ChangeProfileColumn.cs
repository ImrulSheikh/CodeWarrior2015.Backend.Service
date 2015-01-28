namespace EShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProfileColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "ImagePath");
        }
    }
}
