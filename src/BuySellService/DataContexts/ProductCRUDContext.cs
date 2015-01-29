using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using BuySell.EntityModels;

namespace EShopper.DataContexts
{
    public class ProductCRUDContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ProductCRUDContext() : base("ProductCRUDConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                        .Property(p => p.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Product>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<Product>().Property(p => p.UpdatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<Order>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<Order>().Property(p => p.UpdatedOn).HasColumnType("datetime2");

        }
    }
}