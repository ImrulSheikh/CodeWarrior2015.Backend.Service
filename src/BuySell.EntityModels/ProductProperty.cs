namespace CW.Backend.DAL.CRUD.Entities
{
    public class ProductProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product{ get; set; }
    }
}