using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarrior2015.Backend.Service.ProductFlat
{
    public class ProductFlatContext : DbContext
    {
        public DbSet<BuySell.ViewModels.ProductFlat> Products { get; set; }

        public ProductFlatContext() : base("ProductFlat") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuySell.ViewModels.ProductFlat>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<BuySell.ViewModels.ProductFlat>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<BuySell.ViewModels.ProductFlat>().Property(p => p.UpdatedOn).HasColumnType("datetime2");
        }
    }
}
