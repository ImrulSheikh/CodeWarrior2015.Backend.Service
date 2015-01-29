using System.Data.Entity.Migrations;

namespace CW.Backend.DAL.Query.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProductFlatContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductFlatContext context)
        {
        }
    }
}
