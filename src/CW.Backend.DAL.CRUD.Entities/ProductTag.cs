namespace CW.Backend.DAL.CRUD.Entities
{
    public class ProductTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TagType TagType  { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

    public enum TagType
	{
        None = 0,
        UserProvided = 1,
        SystemProvided = 2
	}
}
