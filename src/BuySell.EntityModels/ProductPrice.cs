using System;

namespace CW.Backend.DAL.CRUD.Entities
{
    public class ProductPrice
    {
        public int  Id { get; set; }
        public float UnitPrice { get; set; }
        public float Discount { get; set; }
        public DateTime DiscountValidity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product{ get; set; }
    }
}
