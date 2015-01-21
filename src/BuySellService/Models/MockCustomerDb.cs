using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BuySell.EntityModels;

namespace PatientData.Models
{
    public class MockCustomerDb
    {

        public List<Customer> Customers { get; set; }

        public MockCustomerDb()
        {
            if (Customers == null || Customers.Count() == 0)
            {
                Customers = new List<Customer>();
                for (int i = 0; i < 3; i++)
                {
                    var customer = new Customer() { Id = "id" + i, Name = "Name_" + i };
                    customer.BuyerProfile = new Profile() { Id = "profile_" + i, Address = "Address_" + i, ItemSoldPurchased = i * 10 };
                    customer.SellerProfile = new Profile() { Id = "profile_" + i, Address = "Address_" + i, ItemSoldPurchased = i * 10 };
                    Customers.Add(customer);
                }
            }
        }
    }
}