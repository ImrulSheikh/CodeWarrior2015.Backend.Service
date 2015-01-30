using System;
using System.ComponentModel.DataAnnotations;
using CW.Backend.DAL.Base.Entities;

namespace CW.Backend.DAL.CRUD.Entities
{
    public class Order : BaseCoreEntity
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int OrderedBy { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
