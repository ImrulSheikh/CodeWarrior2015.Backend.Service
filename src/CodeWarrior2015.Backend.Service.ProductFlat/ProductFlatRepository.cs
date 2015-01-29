using System.Data.Entity;
using CW.Backend.DAL.Query.Entities;
using CW.Backend.DAL.RepositoryBase;

namespace CW.Backend.DAL.Query
{
    public class ProductFlatRepository : RepositoryBase<ProductFlat>, IProductFlatRepository
    {
        public ProductFlatRepository(DbContext context) : base(context)
        {
        }
    }
}