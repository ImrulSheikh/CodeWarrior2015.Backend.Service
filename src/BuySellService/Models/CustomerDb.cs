using System.Data.Entity;
using System.Linq;
using BuySell.EntityModels;

namespace EShopper.Models
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Profile> Customers { get; set; }


        public void Add(Profile customer)
        {
            customer.Id = Customers.Max(x => x.Id)+1;

            Customers.Add(customer);
            SaveChanges();
        }
        
    }
}