using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;
using CW.Backend.DAL.Base.Repositories;

namespace CW.Backend.DAL.CRUD.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }

        public IEnumerable<Product> GetMatchingNameAndCategoriesProducts(string searchKey) {
            return GetAllIncluding(p => p.Category.SubCategories)
                .Where(p => p.Name.Contains(searchKey) ||
                            p.Category.Name.Contains(searchKey) ||
                            p.Category.SubCategories.Any(sC => sC.Name.Contains(searchKey)));
        }
    }
}
