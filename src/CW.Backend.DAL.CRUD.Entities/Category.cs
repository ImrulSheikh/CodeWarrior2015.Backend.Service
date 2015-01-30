using System.Collections.Generic;
using CW.Backend.DAL.Base.Entities;

namespace CW.Backend.DAL.CRUD.Entities
{
    public class Category : BaseCoreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryProperty> Properties { get; set; }
        public ICollection<Product> Products { get; set; }

        public int ParentId { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}