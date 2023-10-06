namespace EventStoreDB_ShoppingCart.Events
{
    public class PurchaseCancelledEvent : EventBase
    {
        public decimal TotalAmount { get; set; }
    }
}
