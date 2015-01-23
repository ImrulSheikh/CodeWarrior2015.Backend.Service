using BuySell.EntityModels;

namespace PatientData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PatientData.DataContexts.ProductCRUDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PatientData.DataContexts.ProductCRUDContext context)
        {
            context.Products.AddOrUpdate(p=>p.Id,new Product
                {
                    Name = "Walton Fridge",
                    Category = "Fridge",
                    Price = 200000,
                    CreatedBy = "Ibnoon",
                    CreatedOn = DateTime.Now
                });
        }
    }
}
