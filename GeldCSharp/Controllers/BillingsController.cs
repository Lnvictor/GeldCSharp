using Geld.Core.Entities;
using Geld.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeldCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingsController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingsController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            MonthlyBilling billiing = _billingService.GetBillingById(id);
            return Ok(billiing);
        }

        [HttpGet("ByYear/{year}")]
        public IActionResult GetByYear([FromRoute] int year) {
            List<MonthlyBilling> billings = _billingService.GetBillingsByYear(year);
            return Ok(billings);
        }
    }
}
