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

        public ApplicationUser GetByUserNameIncludingProducts(string userName) {
            return GetAllIncluding(u=>u.Products).First(u => u.UserName == userName);
        }

        public ApplicationUser GetByUserNameIncludingOrders(string userName) {
            return GetAllIncluding(u => u.Orders).First(u => u.UserName == userName);
        }

        public ApplicationUser GetByUserNameIncludingOrdersAndProducts(string userName) {
            return GetAllIncluding(u => u.Orders.Select(o=>o.Products)).First(u => u.UserName == userName);
        }



        public float GetUserRating(string userId) {

            var totalRating = 0;
            var count = 0;

            using (var context = new ProductCRUDContext()) {
                foreach (var product in context.Products.Where(p => p.ApplicationUserId.Equals(userId)).ToList()) {
                    var comments = context.ProductComments.Where(pc => pc.ProductId.Equals(product.Id)).ToList();

                    if (comments.Count != 0) {
                        foreach (var comment in comments) {
                            totalRating += comment.HelpfulHits;
                            count += 1;
                        }
                    }
                }
            }
            float rating = 0;

            if (count != 0) {
                rating = totalRating / count;
            }

            return rating;
        }
    }
}
