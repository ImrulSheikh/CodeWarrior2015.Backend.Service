using System.Data.Entity;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.Query.Entities;
using CW.Backend.DAL.Query.Repositories.Interfaces;

namespace CW.Backend.DAL.Query.Repositories
{
    public class ProductSummaryRepository : RepositoryBase<ProductSummary>, IProductSummaryRepository
    {
        public ProductSummaryRepository(DbContext context) : base(context) { }
    }
}