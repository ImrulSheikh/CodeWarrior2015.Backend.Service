using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuySell.EntityModels;
using BuySell.GenericRepository;
using CodeWarrior2015.Backend.Service.ProductCRUD.Repositories.Interfaces;

namespace CodeWarrior2015.Backend.Service.ProductCRUD.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }
    }
}
