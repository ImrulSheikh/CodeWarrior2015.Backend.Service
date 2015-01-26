using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuySell.EntityModels;

namespace CodeWarrior2015.Backend.Service.ProductCRUD
{
    public class ProductCRUDContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public ProductCRUDContext() : base("ProductCRUD") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
        }
    }
}
