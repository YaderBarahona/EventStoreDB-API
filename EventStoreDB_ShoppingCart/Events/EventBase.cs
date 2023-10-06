namespace EventStoreDB_ShoppingCart.Events
{
    //clases o modelos para las acciones de los eventos del shopping cart

    //add
    //public class ProductAddedToCartEvent
    //{
    //    public string ProductId { get; set; }

    //    public string ProductName { get; set; }

    //    public decimal ProductPrice { get; set; }
    //}

    ////update
    //public class ProductModifiedEvent
    //{
    //    public string ProductId { get; set; }

    //    public string NewName { get; set; }

    //    public decimal NewPrice { get; set; }
    //}

    ////delete
    //public class ProductDeletedEvent
    //{
    //    public string ProductId { get; set; }
    //}

    ////complete
    //public class CheckoutCompletedEvent
    //{
    //    public string ProductId { get; set; }

    //    public decimal TotalAmount { get; set; }
    //}

    ////out of stock
    //public class ProductOutOfStockEvent
    //{
    //    public string ProductId { get; set; }

    //}

    ////restocked product
    //public class ProductRestockedEvent
    //{
    //    public string ProductId { get; set; }

    //    public int Quantity { get; set; }
    //}

    //public class PurchaseConfirmedEvent
    //{
    //    public string ProductId { get; set; }

    //    public decimal TotalAmount { get; set; }
    //}

    //public class PurchaseCancelledEvent
    //{
    //    public string ProductId { get; set; }

    //    public decimal TotalAmount { get; set; }
    //}

    //public class PaymentCompletedEvent
    //{
    //    public string ProductId { get; set; }

    //    public decimal AmountPaid { get; set; }
    //}

    //public class OrderShippedEvent
    //{
    //    public string ProductId { get; set; }

    //    public int OrderId { get; set; }
    //}

    //public class OrderDeliveredEvent
    //{
    //    public string ProductId { get; set; }

    //    public int OrderId { get; set; }
    //}

    public class EventBase
    {
        public string ProductId { get; set; }
    }

}
