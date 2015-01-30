using System.Collections.Generic;

namespace CW.Backend.DAL.CRUD.Entities
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
