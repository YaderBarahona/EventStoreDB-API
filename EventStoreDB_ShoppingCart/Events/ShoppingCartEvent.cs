namespace EventStoreDB_ShoppingCart.Events
{
    public class ShoppingCartEvent
    {
        public string CartId { get; set; }
        public string CustomerId { get; set; }
        public List<Product> Products { get; set; }
        public DateTime Date { get; set; }

        public double Total { get; set; }
        public double SubTotal { get; set; }
       
    }
}
