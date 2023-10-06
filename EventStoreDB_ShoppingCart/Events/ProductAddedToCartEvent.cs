namespace EventStoreDB_ShoppingCart.Events
{
    public class ProductAddedToCartEvent : EventBase
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
