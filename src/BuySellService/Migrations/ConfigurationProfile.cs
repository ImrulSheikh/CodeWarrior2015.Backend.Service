using System;
using System.Data.Entity.Migrations;
using CW.Backend.DAL.CRUD.Entities;

namespace EShopper.Migrations
{
    internal sealed class ConfigurationProfile : DbMigrationsConfiguration<EShopper.DataContexts.ProfileDbContext>
    {
        public ConfigurationProfile()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EShopper.DataContexts.ProfileDbContext context)
        {
            context.Profiles.AddOrUpdate(p=>p.Id,new Profile()
                {
                    CreatedBy = "Ibnoon",
                    CreatedOn = DateTime.Now
                });
        }
    }
}
