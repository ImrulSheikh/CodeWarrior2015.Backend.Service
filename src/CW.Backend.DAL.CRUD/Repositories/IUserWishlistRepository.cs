using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.CRUD.Entities;

namespace CW.Backend.DAL.CRUD.Repositories
{
    public interface IUserWishlistRepository:IRepository<UserWishlist>
    {
        UserWishlist GetByUserName(string userName);
        UserWishlist GetByUserId(string userId);
        UserWishlist GetByCurrentUser();
        void AddProduct(string userId, Product product)
    }
}