using System.Data.Entity;
using System.Linq;
using BuySell.EntityModels;

namespace PatientData.Models
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Customer> Customers { get; set; }


        public void Add(Customer customer)
        {
            customer.Id = Customers.Max(x => x.Id)+1;

            Customers.Add(customer);
            SaveChanges();
        }
        
    }
}