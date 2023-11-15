using Geld.Core.Entities;
using Geld.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GeldCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get([FromRoute] int id)
        {
            var order = _orderService.Retrieve(id);
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            _orderService.Add(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id}, order);
        }
    }
}
