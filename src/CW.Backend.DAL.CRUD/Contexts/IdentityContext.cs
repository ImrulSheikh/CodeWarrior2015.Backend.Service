using CW.Backend.DAL.CRUD.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CW.Backend.DAL.CRUD.Contexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        private const string DefaultConnectionName = "CW_CRUD";

        public IdentityContext()
            : this(DefaultConnectionName)
        {

        }

        public IdentityContext(string connectionName = DefaultConnectionName)
            : base(connectionName)
        {


        }


        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
