namespace EventStoreDB_ShoppingCart.Events
{
    public class ShoppingCartEvent
    {
        public string CustomerId { get; set; }
        public List<Product> Products { get; set; }

        public double SubTotal { get; set; }
        public double Total { get; set; }
    }
}
