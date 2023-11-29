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
    public class BillingsController : ControllerBase
    {
        private readonly IBillingService _billingService;
        private readonly ILogger _logger;

        public BillingsController(IBillingService billingService, ILogger<BillingsController> logger)
        {
            _billingService = billingService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                MonthlyBilling billiing = _billingService.GetBillingById(id);
                return Ok(BillingDTO.ToDTO(billiing));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in getting billings: Exception: {ex}");
                return Problem("Something went wrong. Please check the app logs");
            }
        }

        [HttpGet("ByYear/{year}")]
        public IActionResult GetByYear([FromRoute] int year) {
            try
            {
                List<MonthlyBilling> billings = _billingService.GetBillingsByYear(year);
                return Ok(BillingDTO.ToDTO(billings));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in getting billings by year: Exception: {ex}");
                return Problem("Something went wrong. Please check the app logs");
            }
        }
    }
}
