using System.Linq;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.CRUD.Entities;

namespace CW.Backend.DAL.CRUD.Repositories.Interfaces {
    public interface IUserRepository : IRepository<ApplicationUser> {
        float GetUserRating(string userId);
        ApplicationUser GetByUserName(string userName);

        ApplicationUser GetByUserNameIncludingProducts(string userName);

        ApplicationUser GetByUserNameIncludingOrders(string userName);

        ApplicationUser GetByUserNameIncludingOrdersAndProducts(string userName);
    }
}
