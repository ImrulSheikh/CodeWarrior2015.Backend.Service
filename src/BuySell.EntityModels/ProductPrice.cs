using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySell.EntityModels
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
