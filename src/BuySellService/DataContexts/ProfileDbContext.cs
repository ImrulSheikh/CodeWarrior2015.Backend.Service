using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BuySell.EntityModels;
using System.Data.Entity;

namespace EShopper.DataContexts
{
    public class ProfileDbContext : DbContext
    {

        public DbSet<Profile> Profiles { get; set; }

        public ProfileDbContext()
            : base("DefaultConnection")
        {
            


        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profile>()
                        .Property(p => p.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Profile>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<Profile>().Property(p => p.UpdatedOn).HasColumnType("datetime2");

        }

        public void Add(Profile profile)
        {
            //var max = Profiles.Max(x => x.Id);

            //var id = 0;
            //if (max == null)
            //{
            //    id = 1;
            //}
            //else
            //{
            //    id = int.Parse(max) + 1;
            //}
            

            //profile.Id = id.ToString();

            Profiles.Add(profile);
            SaveChanges();
        }
       
    }
}