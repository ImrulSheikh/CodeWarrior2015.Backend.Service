using System.Data.Entity;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;

namespace CW.Backend.DAL.CRUD.Repositories
{
    public class ProductPropertyRepository :RepositoryBase<ProductProperty>, IProductPropertyRepository
    {
        public ProductPropertyRepository():base(new ProductCRUDContext())
        {
            
        }
        public ProductPropertyRepository(DbContext context) : base(context)
        {
        }
    }
}