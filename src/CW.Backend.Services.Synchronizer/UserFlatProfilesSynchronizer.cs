using System;
using System.Collections.Generic;
using System.Linq;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using CW.Backend.DAL.Query;
using CW.Backend.DAL.Query.Entities;
using CW.Backend.DAL.Query.Repositories;

namespace CW.Backend.Services.Synchronizer
{
    public class UserFlatProfilesSynchronizer
    {
        private static DateTime LastSynced;
        public void Sync()
        {
            var syncingTime = DateTime.Now;
            var crudContext = new ProductCRUDContext();
            var queryContext = new ProductFlatContext();
            IEnumerable<UserFlatProfile> userFlatEntries;

            using (var cRepo = new UserRepository(crudContext))
            {
                var usersToBeUpdated =
                    cRepo.GetAll().Where(p => p.UpdatedOn >= LastSynced && p.UpdatedOn <= syncingTime);
               userFlatEntries = GetUserFlatEntries(usersToBeUpdated,syncingTime);               
            }

            try
            {
                using (var qRepo = new UserFlatRepository(queryContext))
                {
                    qRepo.AddRange(userFlatEntries);
                    qRepo.Save();
                }
            }
            catch (Exception)
            {
                return;
            }

            LastSynced = syncingTime;
        }

        private IEnumerable<UserFlatProfile> GetUserFlatEntries(IEnumerable<ApplicationUser> users, DateTime syncingTime)
        {
            return users.Select(user => new UserFlatProfile
            {
                CreatedBy = user.CreatedBy,
                CreatedOn = user.CreatedOn,
                UpdatedBy = user.UpdatedBy,
                Status = user.Status,
                Address = user.Address,
                Email = user.Email,
                FullName = user.FullName,
                Sex = user.Sex,
                Mobile = user.Mobile,
                UserName = user.UserName,
                Password = user.PasswordHash,
                UpdatedOn = syncingTime
            });
        }
    }
}
