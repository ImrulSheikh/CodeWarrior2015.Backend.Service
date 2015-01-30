using System.Data.Entity;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;
using CW.Backend.DAL.Base.Repositories;

namespace CW.Backend.DAL.CRUD.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
