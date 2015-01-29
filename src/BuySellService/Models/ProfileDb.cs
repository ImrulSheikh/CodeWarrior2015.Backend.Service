using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuySell.EntityModels;

namespace EShopper.Models
{
    public class ProfileDb 
    {
        public static List<Profile> GetGata()
        {
            var data = new List<Profile>();
            for (int i = 0; i < 3; i++)
            {
                data.Add(new Profile() { Id = "id" + i, ProfileType = "Type_" + i,Address = "Address_"+i,ItemSoldPurchased = i});
            }
            return data;

        }

        public static bool SaveProfile(RegisterBindingModel model)
        {
            return true;

        }
    }
}