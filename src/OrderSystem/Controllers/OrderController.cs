using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderSystem.Models;
using OrderSystem.Services;
using OrderSystem.Shared;

namespace OrderSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        public readonly IOrderService _orderService;

        public OrderController(IOrderService orderService,
                               ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid uid)
        {
            var isExist = await _orderService.IsOrderExistAsync(uid);
            if (!isExist)
                return NotFound();

            var order = await _orderService.GetOrderAsync(uid);

            return Ok(order);
        }

        //[HttpGet("customer/{customerUid}")]
        //public async Task<IActionResult> GetCustomerOrder(Guid customerUid)
        //{
        //    var order = await _orderService.GetCustomerOrderAsync(customerUid);
        //    return order is null ? (IActionResult)NotFound() : Ok(order);
        //}


        //[HttpPost]
        //public async Task<IActionResult> CreateNewOrder(Guid customerUid)
        //{
        //    var newOrder = new NewOrder(customerUid, DateTime.Now);
        //    var orderGuid = await _orderService.CreateOrderAsync(newOrder);
        //    return Ok(orderGuid);
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateOrder()
        //{
        //    return NoContent();
        //}
    }
}
