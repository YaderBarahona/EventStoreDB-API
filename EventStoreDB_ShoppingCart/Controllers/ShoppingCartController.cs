using EventStoreDB_ShoppingCart.Events;
using EventStoreDB_ShoppingCart.Exceptions;
using EventStoreDB_ShoppingCart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventStoreDB_ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IEventStoreService _eventService;

        public ShoppingCartController(IEventStoreService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("events")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EventBase>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetEvents()
        {
            try
            {
                var events = await _eventService.GetEvents();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDetails(500, "Error interno del servidor"));
            }
        }


        [HttpPost("addProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddedToCartEvent @event)
        {
            try
            {
                var result = await _eventService.ProductAddedToCart(@event);
                return Ok(result);
            }
            catch (CustomException ex)
            {
                return BadRequest(new ErrorDetails(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDetails(500, "Error interno del servidor"));
            }
        }

        [HttpPost("removeProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> RemoveProduct([FromBody] ProductRemovedFromCartEvent @event)
        {
            try
            {
                var result = await _eventService.ProductRemovedFromCart(@event);
                return Ok(result);
            }
            catch (CustomException ex)
            {
                return BadRequest(new ErrorDetails(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDetails(500, "Error interno del servidor"));
            }
        }

        [HttpPost("checkout")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Checkout([FromBody] CheckoutCompletedEvent @event)
        {
            try
            {
                var result = await _eventService.Checkout(@event);
                return Ok(result);
            }
            catch (CustomException ex)
            {
                return BadRequest(new ErrorDetails(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDetails(500, "Error interno del servidor"));
            }
        }

        [HttpPost("purchaseConfirmed")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> PurchaseConfirmed([FromBody] PurchaseConfirmedEvent @event)
        {
            try
            {
                var result = await _eventService.PurchaseConfirmed(@event);
                return Ok(result);
            }
            catch (CustomException ex)
            {
                return BadRequest(new ErrorDetails(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDetails(500, "Error interno del servidor"));
            }
        }

        [HttpPost("purchaseCancelled")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> PurchaseCancelled([FromBody] PurchaseCancelledEvent @event)
        {
            try
            {
                var result = await _eventService.PurchaseCancelled(@event);
                return Ok(result);
            }
            catch (CustomException ex)
            {
                return BadRequest(new ErrorDetails(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDetails(500, "Error interno del servidor"));
            }
        }

        [HttpPost("paymentCompleted")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> PaymentCompleted([FromBody] PaymentCompletedEvent @event)
        {
            try
            {
                var result = await _eventService.PaymentCompleted(@event);
                return Ok(result);
            }
            catch (CustomException ex)
            {
                return BadRequest(new ErrorDetails(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDetails(500, "Error interno del servidor"));
            }
        }

        //[HttpPost("orderShipped")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        //public async Task<IActionResult> OrderShipped([FromBody] OrderShippedEvent @event)
        //{
        //    try
        //    {
        //        var result = await _eventService.OrderShipped(@event);
        //        return Ok(result);
        //    }
        //    catch (CustomException ex)
        //    {
        //        return BadRequest(new ErrorDetails(400, ex.Message));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new ErrorDetails(500, "Error interno del servidor"));
        //    }
        //}

        //    [HttpPost("orderDelivered")]
        //    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        //    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        //    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        //    public async Task<IActionResult> OrderDelivered([FromBody] OrderDeliveredEvent @event)
        //    {
        //        try
        //        {
        //            var result = await _eventService.OrderDelivered(@event);
        //            return Ok(result);
        //        }
        //        catch (CustomException ex)
        //        {
        //            return BadRequest(new ErrorDetails(400, ex.Message));
        //        }
        //        catch (Exception ex)
        //        {
        //            return StatusCode(500, new ErrorDetails(500, "Error interno del servidor"));
        //        }
        //    }
        
    }
}
