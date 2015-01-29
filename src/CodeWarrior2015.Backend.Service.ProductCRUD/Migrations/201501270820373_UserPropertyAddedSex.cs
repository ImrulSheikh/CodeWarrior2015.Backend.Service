using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.CRUD.Migrations
{
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
