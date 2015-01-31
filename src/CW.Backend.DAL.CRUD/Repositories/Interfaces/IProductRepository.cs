using System.Collections.Generic;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.CRUD.Entities;

namespace CW.Backend.DAL.CRUD.Repositories.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> GetMatchingNameAndCategoriesProducts(string searchKey);
    }
}
