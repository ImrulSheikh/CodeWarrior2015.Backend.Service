using CW.Backend.DAL.CRUD.Entities;

namespace CW.Backend.DAL.Query.Entities
{
    public class ProductFlat : BaseCoreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfUnits { get; set; }
        public string ImagePath { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
        public string Properties { get; set; }
        public string Prices { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int PostedUserId { get; set; }
        public string PostedBy { get; set; }
    }
}
