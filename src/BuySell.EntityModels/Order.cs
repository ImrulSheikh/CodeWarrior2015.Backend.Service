using System;
using System.ComponentModel.DataAnnotations;

namespace BuySell.EntityModels
{
    public class Order:BaseCoreEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
