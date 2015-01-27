namespace BuySell.EntityModels
{
    public class CategoryProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}