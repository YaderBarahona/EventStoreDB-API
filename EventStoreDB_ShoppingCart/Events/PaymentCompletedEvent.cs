namespace EventStoreDB_ShoppingCart.Events
{
    public class PaymentCompletedEvent : EventBase
    {

        public decimal AmountPaid { get; set; }
    }
}
