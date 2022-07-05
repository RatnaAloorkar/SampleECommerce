using System;
using SampleECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using SampleECommerce.Service.Interfaces;


namespace SampleECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        #region Constructor and Member Variables
        private readonly IOrderService _orderService;
        private readonly IShippingRulesService _shippingRulesService;

        public OrdersController(IOrderService orderService, IShippingRulesService shippingRulesService)
        {
            _orderService = orderService;
            _shippingRulesService = shippingRulesService;
        }
        #endregion

        #region Get Methods
        [HttpGet("shippingprice/{total}")]
        public ActionResult<double> GetShippingPrice(float total)
        {
            try
            {
                var result = _shippingRulesService.GetShippingPrice(total);
                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Post Methods

        [HttpGet]
        public ActionResult<Order> GetOrder(Guid orderNumber)
        {
            try
            {
                var order = _orderService.GetOrder(orderNumber);
                return Ok(order);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPost("checkout")]
        public ActionResult Checkout([FromBody]Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orderNumber = _orderService.PlaceOrder(order);

                    if (orderNumber == Guid.Empty)
                    {
                        return UnprocessableEntity("Order could not be placed at the moment. Please try again after some time.");
                    }
                    else
                    {
                        return CreatedAtAction(nameof(GetOrder), orderNumber);
                    }
                }
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
