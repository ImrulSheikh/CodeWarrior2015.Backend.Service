using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using CW.Backend.DAL.Query.Entities;

namespace CW.Backend.DAL.Query.Repositories
{
    public class ProductFlatContext : DbContext
    {
        public DbSet<ProductDetails> AllProductDetails { get; set; }
        public DbSet<ProductSummary> ProductSummaries { get; set; }
        public DbSet<UserFlatProfile> Users { get; set; }

        public ProductFlatContext() : base("ProductFlat") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetails>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<ProductDetails>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<ProductDetails>().Property(p => p.UpdatedOn).HasColumnType("datetime2");

            modelBuilder.Entity<ProductSummary>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<ProductSummary>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<ProductSummary>().Property(p => p.UpdatedOn).HasColumnType("datetime2");

            modelBuilder.Entity<UserFlatProfile>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<UserFlatProfile>().Property(p => p.UpdatedOn).HasColumnType("datetime2");
        }
    }
}
