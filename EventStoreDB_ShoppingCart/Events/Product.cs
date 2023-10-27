namespace EventStoreDB_ShoppingCart.Events
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
