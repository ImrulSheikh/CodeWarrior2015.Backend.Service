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
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        public DbSet<User> Users { get; set; }

        public ProductCRUDContext() : base("ProductCRUD") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.PostedBy);

            modelBuilder.Entity<Product>().HasMany(p => p.Groups).WithMany(g => g.Products);
        }
    }
}
