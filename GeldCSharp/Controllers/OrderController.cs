using Geld.Core.Entities;
using Geld.Core.Services.Abstract;
using GeldCSharp.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeldCSharp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IBillingService _billingService;
        private readonly IInstallmentService _installmentService;

        private readonly ILogger _logger;

        public OrderController(IOrderService orderService, IBillingService billingService, IInstallmentService installmentService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _billingService = billingService;
            _installmentService = installmentService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromRoute] int id)
        {
            try {
                var order = _orderService.Retrieve(id);
                return Ok(OrderDTO.ToDTO(order));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in getting order: Exception: {ex}");
                return Problem("Something went wrong. Please check the app logs");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            try
            {
                _orderService.Add(order);
                var billings = _billingService.UpdateMonthlyBillings(order);
                _installmentService.CreateInstallmentsForOrder(order, billings);
                return CreatedAtAction(nameof(Get), new { id = order.Id }, OrderDTO.ToDTO(order));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in creating order: Exception: {ex}");
                return Problem("Something went wrong. Please check the app logs");
            }
        }
    }
}
