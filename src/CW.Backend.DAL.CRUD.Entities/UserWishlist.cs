using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW.Backend.DAL.CRUD.Entities
{
    public class UserWishlist
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
