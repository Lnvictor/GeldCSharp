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
    public class InstallmentsController : ControllerBase
    {
        private readonly IInstallmentService _installmentService;

        private readonly ILogger _logger;

        public InstallmentsController(IInstallmentService installmentService, ILogger<InstallmentsController> logger) { 
            _installmentService = installmentService;
            _logger = logger;
        }

        [HttpGet("GetByBilling/{id}")]
        public IActionResult actionResult([FromRoute] int id)
        {
            try
            {
                List<Installment> installments = _installmentService.GetInstallmentsByBillings(id);
                return Ok(InstallmentDTO.ToDTO(installments));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in getting installments: Exception: {ex}");
                return Problem("Something went wrong. Please check the app logs");
            }
        }
    }
}
