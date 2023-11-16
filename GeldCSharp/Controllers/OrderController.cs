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
        private readonly IBillingService _billingService;
        private readonly IInstallmentService _installmentService;

        public OrderController(IOrderService orderService, IBillingService billingService, IInstallmentService installmentService)
        {
            _orderService = orderService;
            _billingService = billingService;
            _installmentService = installmentService;
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
            var billings = _billingService.UpdateMonthlyBillings(order);
            _installmentService.CreateInstallmentsForOrder(order, billings);
            return CreatedAtAction(nameof(Get), new { id = order.Id}, order);
        }
    }
}
