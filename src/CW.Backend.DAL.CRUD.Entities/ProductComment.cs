namespace CW.Backend.DAL.CRUD.Entities
{
    public class ProductComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int StarRating { get; set; }
        public int HelpfulHits { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
