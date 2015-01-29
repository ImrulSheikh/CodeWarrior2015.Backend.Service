namespace CW.Backend.DAL.CRUD.Entities
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Profile BuyerProfile { get; set; }
        public Profile SellerProfile { get; set; }
    }
}