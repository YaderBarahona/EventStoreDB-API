using System.Text;
using System.Text.Json;
using EventStore.Client;
using EventStoreDB_ShoppingCart.Events;
using EventStoreDB_ShoppingCart.Exceptions;
using Microsoft.Extensions.Logging;

namespace EventStoreDB_ShoppingCart.Services
{
    public class EventStoreService : IEventStoreService
    {
        private readonly EventStoreClient _eventStoreClient;

        public EventStoreService(EventStoreClient eventStoreClient)
        {
            _eventStoreClient = eventStoreClient;
        }

        //obtener todos los eventos en forma de texto

        public async Task<IEnumerable<string>> GetEvents()
        {
            //nombre del stream
            var streamName = "shopping_cart_stream";

            var events = _eventStoreClient.ReadStreamAsync(
                Direction.Forwards,
                streamName,
                StreamPosition.Start);

            List<string> eventMessages = new List<string>();

            await foreach (var @event in events)
            {
                var eventType = @event.Event.EventType;
                var eventData = Encoding.UTF8.GetString(@event.Event.Data.ToArray());

                var eventMessage = $"EventType: {eventType}, Data: {eventData}";
                eventMessages.Add(eventMessage);
            }

            return eventMessages;
        }

        public async Task<string> ProductAddedToCart(ProductAddedToCartEvent @event)
        {
            ValidateEvent(@event);

            @event.ProductId = Guid.NewGuid().ToString("N");
            var eventData = CreateEventData("ProductAddedToCartEvent", @event);

            await AppendEventToStream(eventData);

            return "Producto agregado al carrito";
        }

        public async Task<string> ProductRemovedFromCart(ProductRemovedFromCartEvent @event)
        {
            ValidateEvent(@event);

            @event.ProductId = Guid.NewGuid().ToString("N");
            var eventData = CreateEventData("ProductRemovedFromCartEvent", @event);

            await AppendEventToStream(eventData);

            return "Producto eliminado del carrito";
        }

        public async Task<string> Checkout(CheckoutCompletedEvent @event)
        {
            ValidateEvent(@event);

            @event.ProductId = Guid.NewGuid().ToString("N");
            var eventData = CreateEventData("CheckoutCompletedEvent", @event);

            await AppendEventToStream(eventData);

            return "Compra realizada con éxito";
        }

        public async Task<string> PurchaseConfirmed(PurchaseConfirmedEvent @event)
        {
            ValidateEvent(@event);

            @event.ProductId = Guid.NewGuid().ToString("N");
            var eventData = CreateEventData("PurchaseConfirmedEvent", @event);

            await AppendEventToStream(eventData);

            return "Compra confirmada";
        }

        public async Task<string> PurchaseCancelled(PurchaseCancelledEvent @event)
        {
            ValidateEvent(@event);

            @event.ProductId = Guid.NewGuid().ToString("N");
            var eventData = CreateEventData("PurchaseCancelledEvent", @event);

            await AppendEventToStream(eventData);

            return "Compra cancelada";
        }

        public async Task<string> PaymentCompleted(PaymentCompletedEvent @event)
        {
            ValidateEvent(@event);

            @event.ProductId = Guid.NewGuid().ToString("N");
            var eventData = CreateEventData("PaymentCompletedEvent", @event);

            await AppendEventToStream(eventData);

            return "Pago completado";
        }


        //public async Task<string> OrderShipped(OrderShippedEvent @event)
        //{
        //    ValidateEvent(@event);

        //    @event.ProductId = Guid.NewGuid().ToString("N");
        //    var eventData = CreateEventData("OrderShippedEvent", @event);

        //    await AppendEventToStream(eventData);

        //    return "Pedido enviado";
        //}

        //public async Task<string> OrderDelivered(OrderDeliveredEvent @event)
        //{
        //    ValidateEvent(@event);

        //    @event.ProductId = Guid.NewGuid().ToString("N");
        //    var eventData = CreateEventData("OrderDeliveredEvent", @event);

        //    await AppendEventToStream(eventData);

        //    return "Pedido entregado";
        //}

        //metodo para validar cada evento (para ahorrar codigo y solo llamarlo en cada metodo de cada evento)
        private void ValidateEvent(object @event)
        {
            if (@event == null)
            {
                throw new CustomException("El evento es nulo");
            }

            if (@event is ProductAddedToCartEvent addedEvent && string.IsNullOrWhiteSpace(addedEvent.ProductId))
            {
                throw new CustomException("El Id no puede estar vacío");
            }
        }

        private EventData CreateEventData(string eventType, object @event)
        {
            return new EventData(
                Uuid.NewUuid(),
                eventType,
                JsonSerializer.SerializeToUtf8Bytes(@event)
            );
        }

        private async Task AppendEventToStream(params EventData[] eventData)
        {
            await _eventStoreClient.AppendToStreamAsync(
                "shopping_cart_stream",
                StreamState.Any,
                eventData
            );
        }
    }
}
