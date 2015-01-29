using System.Data.Entity;
using BuySell.GenericRepository;

namespace CodeWarrior2015.Backend.Service.ProductFlat
{
    public class ProductFlatRepository : RepositoryBase<BuySell.ViewModels.ProductFlat>, IProductFlatRepository
    {
        public ProductFlatRepository(DbContext context) : base(context) { }
    }
}