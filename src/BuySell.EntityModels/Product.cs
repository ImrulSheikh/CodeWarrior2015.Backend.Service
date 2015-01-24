using System.ComponentModel.DataAnnotations;

namespace BuySell.EntityModels
{
    public class Product: BaseCoreEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
