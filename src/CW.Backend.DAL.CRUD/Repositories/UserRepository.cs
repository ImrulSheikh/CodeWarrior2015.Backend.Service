using System.Data.Entity;
using System.Linq;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;
using CW.Backend.DAL.Base.Repositories;

namespace CW.Backend.DAL.CRUD.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public ApplicationUser GetByUserId(string userId)
        {

            foreach (var user in this.GetAll())
            {
                var p = user.Id;
            }


            return this.GetAll().FirstOrDefault();
        }
    }
}
