using System.Collections.Generic;
using CW.Backend.DAL.Base.Entities;

namespace CW.Backend.DAL.CRUD.Entities {
    public class User : BaseCoreEntity {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}