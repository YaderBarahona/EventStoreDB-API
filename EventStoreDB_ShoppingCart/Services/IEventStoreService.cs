using EventStore.Client;
using EventStoreDB_ShoppingCart.Events;
using Microsoft.Extensions.Logging;

namespace EventStoreDB_ShoppingCart.Services
{
    public interface IEventStoreService
    {
        Task<IEnumerable<string>> GetEvents();
        Task<string> ShoppingCartEvent(ShoppingCartEvent @event);
        Task<string> ProductAddedToCart(ProductAddedToCartEvent @event);
        Task<string> ProductRemovedFromCart(ProductRemovedFromCartEvent @event);
        Task<string> Checkout(CheckoutCompletedEvent @event);
        Task<string> PurchaseConfirmed(PurchaseConfirmedEvent @event);
        Task<string> PurchaseCancelled(PurchaseCancelledEvent @event);
        Task<string> PaymentCompleted(PaymentCompletedEvent @event);

        //Task<string> OrderShipped(OrderShippedEvent @event);
        //Task<string> OrderDelivered(OrderDeliveredEvent @event);

        Task SubscribeToStream(string connectionId, Action<string> eventReceivedCallback);
        Task UnsubscribeFromStream(string connectionId);

    }
}
