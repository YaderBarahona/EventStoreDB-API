namespace EventStoreDB_ShoppingCart.Events
{
    public class CheckoutCompletedEvent : EventBase
    {

        public decimal TotalAmount { get; set; }
    }
}
