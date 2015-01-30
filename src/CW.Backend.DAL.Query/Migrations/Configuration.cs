using CW.Backend.DAL.Query;
using CW.Backend.DAL.Query.Repositories;

namespace CodeWarrior2015.Backend.Service.ProductFlat.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
