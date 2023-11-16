using Geld.Core.Entities;
using Geld.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeldCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsController : ControllerBase
    {
        private readonly IInstallmentService _installmentService;

        public InstallmentsController(IInstallmentService installmentService) { 
            _installmentService = installmentService;
        }

        [HttpGet("GetByBilling/{id}")]
        public IActionResult actionResult([FromRoute] int id)
        {
            List<Installment> installments = _installmentService.GetInstallmentsByBillings(id);
            return Ok(installments);
        }
    }
}
