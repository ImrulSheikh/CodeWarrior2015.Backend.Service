using BuySell.EntityModels;
using System;
using System.Data.Entity.Migrations;

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
