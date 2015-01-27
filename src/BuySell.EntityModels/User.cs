using System.Collections.Generic;

namespace BuySell.EntityModels
{
    public class User:BaseCoreEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}