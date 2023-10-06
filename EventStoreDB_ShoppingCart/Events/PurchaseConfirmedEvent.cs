namespace EventStoreDB_ShoppingCart.Events
{
    public class PurchaseConfirmedEvent : EventBase
    {
        public decimal TotalAmount { get; set; }
    }
}
