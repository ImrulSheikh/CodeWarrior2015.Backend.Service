using System.Data.Entity;
using System.Linq;
using System.Threading;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;
using CW.Backend.DAL.Base.Repositories;

namespace CW.Backend.DAL.CRUD.Repositories {
    public class UserWishlistRepository : RepositoryBase<UserWishlist>, IUserWishlistRepository {
        public UserWishlistRepository()
            : base(new ProductCRUDContext()) {
        }
        public UserWishlistRepository(DbContext context) : base(context) { }

        public UserWishlist GetByUserName(string userName)
        {
            return new UserWishlist();
        }

        public UserWishlist GetByUserId(string userId)
        {
            return new UserWishlist();
        }

        public void AddProduct(string userId, Product product)
        {
        }
    }
}
