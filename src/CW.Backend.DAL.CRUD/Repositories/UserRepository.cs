using System.Data.Entity;
using System.Linq;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;
using CW.Backend.DAL.Base.Repositories;

namespace CW.Backend.DAL.CRUD.Repositories {
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository {
        public UserRepository()
            : base(new ProductCRUDContext()) {
        }
        public UserRepository(DbContext context) : base(context) { }

        public ApplicationUser GetByUserName(string userName) {
            return GetAll().First(u => u.UserName == userName);
        }
    }
}
