using System;
using System.Data.Entity.Migrations;
using CW.Backend.DAL.CRUD.Entities;

namespace EShopper.Migrations
{
    internal sealed class ConfigurationProduct : DbMigrationsConfiguration<EShopper.DataContexts.ProductCRUDContext>
    {
        public ConfigurationProduct()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EShopper.DataContexts.ProductCRUDContext context)
        {
            context.Products.AddOrUpdate(p=>p.Id,new Product
                {
                    Name = "Walton Fridge",
                    //Category = "Fridge",
                    //Price = 200000,
                    CreatedBy = "Ibnoon",
                    CreatedOn = DateTime.Now
                });
        }
    }
}
