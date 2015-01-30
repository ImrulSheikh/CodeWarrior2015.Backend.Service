using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CW.Backend.DAL.Base.Entities;

namespace CW.Backend.DAL.CRUD.Entities {
    public class Order : BaseCoreEntity {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
