namespace EventStoreDB_ShoppingCart.Events
{
    public class OrderDeliveredEvent : EventBase
    {

        public int OrderId { get; set; }
    }
}
