namespace EventStoreDB_ShoppingCart.Events
{
    public class OrderShippedEvent : EventBase
    {

        public int OrderId { get; set; }
    }
}
