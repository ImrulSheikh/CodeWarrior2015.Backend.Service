using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuySell.EntityModels;
using System.Data.Entity;

namespace EShopper.Models
{
    public class ProfileDbContext : DbContext
    {

        public DbSet<Profile> Profiles { get; set; }

        public ProfileDbContext()
            : base("DefaultConnection")
        {

        }
        //public static List<Profile> GetGata()
        //{
        //    var data = new List<Profile>();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        data.Add(new Profile() { Id = "id" + i, ProfileType = "Type_" + i,Address = "Address_"+i,ItemSoldPurchased = i});
        //    }
        //    return data;

        //}

        //public static bool SaveProfile(RegisterBindingModel model)
        //{
        //    return true;

        //}
    }
}