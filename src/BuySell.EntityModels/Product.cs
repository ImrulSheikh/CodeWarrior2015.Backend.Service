using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuySell.EntityModels
{
    public class Product: BaseCoreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductProperty> Properties { get; set; }
        public ICollection<ProductPrice> Prices { get; set; }

        public int PostedBy { get; set; }
        public virtual Category Category { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
