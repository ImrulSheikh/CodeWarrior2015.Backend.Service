using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using CW.Backend.DAL.Query.Entities;

namespace CW.Backend.DAL.Query
{
    public class ProductFlatContext : DbContext
    {
        public DbSet<ProductFlat> Products { get; set; }

        public ProductFlatContext() : base("ProductFlat") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductFlat>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<ProductFlat>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<ProductFlat>().Property(p => p.UpdatedOn).HasColumnType("datetime2");
        }
    }
}
