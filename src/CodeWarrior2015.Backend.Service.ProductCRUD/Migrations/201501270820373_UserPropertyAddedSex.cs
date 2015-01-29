namespace CodeWarrior2015.Backend.Service.ProductCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPropertyAddedSex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Sex", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Sex");
        }
    }
}
