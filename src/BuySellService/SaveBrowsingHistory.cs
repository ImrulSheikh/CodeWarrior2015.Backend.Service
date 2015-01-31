using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;

namespace EShopper.BackgroundJob
{
    public class SaveBrowsingHistory
    {
        protected ApplicationUser User;
        protected Product Product;
        public SaveBrowsingHistory(ApplicationUser user,Product product)
        {
            User = user;
            Product = product;
        }

        public SaveBrowsingHistory(string userName, string searchKey)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            // do save;   
        }
    }
}