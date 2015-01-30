using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.Query.Entities;
using CW.Backend.DAL.Query.Repositories.Interfaces;

namespace CW.Backend.DAL.Query.Repositories
{
    public class UserFlatRepository : RepositoryBase<UserFlatProfile>, IUserFlatRepository
    {
        public UserFlatRepository()
            : base(new ProductFlatContext())
        {

        }
        public UserFlatRepository(ProductFlatContext context)
            : base(context)
        {
        }
    }
}