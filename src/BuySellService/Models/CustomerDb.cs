using System.Data.Entity;
using System.Linq;
using BuySell.EntityModels;

namespace PatientData.Models
{
    public class CustomerDb : DbContext
    {
        public CustomerDb()
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Customer> GetGata()
        {
            if (Customers == null || Customers.Count() == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    var customer = new Customer() { Id = "id" + i, Name = "Name_" + i };
                    customer.BuyerProfile = new Profile() { Address = "Address_" + i, ItemSoldPurchased = i * 10 };
                    Customers.Add(customer);
                }
            }

            return Customers;

        }
    }
}