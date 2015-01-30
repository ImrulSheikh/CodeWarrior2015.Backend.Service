using System.Data.Entity;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;

namespace CW.Backend.DAL.CRUD.Repositories
{
    public class ProductCommentRepository : RepositoryBase<ProductComment>, IProductCommentRepository
    {
        public ProductCommentRepository() : base(new ProductCRUDContext()) { }
        public ProductCommentRepository(DbContext context) : base(context) { }
    }
}