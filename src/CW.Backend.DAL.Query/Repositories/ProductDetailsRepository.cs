using System.Data.Entity;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.Query.Entities;
using CW.Backend.DAL.Query.Repositories.Interfaces;

namespace CW.Backend.DAL.Query.Repositories
{
    public class ProductDetailsRepository : RepositoryBase<ProductDetails>, IProductDetailsRepository
    {
        public ProductDetailsRepository(DbContext context) : base(context) { }
    }
}