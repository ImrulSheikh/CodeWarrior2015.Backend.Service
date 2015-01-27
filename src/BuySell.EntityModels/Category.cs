using System.Collections.Generic;

namespace BuySell.EntityModels
{
    public class Category:BaseCoreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryProperty> Properties { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}