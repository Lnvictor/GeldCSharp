using Geld.Core.Entities;
using Geld.Core.Exceptions;
using Geld.Core.Services.Abstract;
using GeldCSharp.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeldCSharp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;
        private readonly ILogger _logger;

        public PaymentController(IPaymentService service, ILogger<PaymentController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("/ByBilling/{billingId}")]
        public IActionResult GetPaymentHistory([FromRoute] int billingId)
        {
            try
            {
                var payments = _service.GetPaymentHistory(billingId);
                return Ok(PaymentDTO.ToDTO(payments));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in getting payment history: Exception: {ex}");
                return Problem("Something went wrong. Please check the app logs");
            }
        }

        [HttpGet]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                Payment payment = _service.GetPayment(id);
                return Ok(PaymentDTO.ToDTO(payment));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in getting payment: Exception: {ex}");
                return Problem("Something went wrong. Please check the app logs");
            }
        }

        [HttpPost]
        public IActionResult DoPayment([FromBody] PaymentDTO paymentDto)
        {
            try
            {
                Payment payment = _service.DoPayment(paymentDto.BillingId, paymentDto.Value);
                return CreatedAtAction(nameof(Get), new { id = payment.Id }, PaymentDTO.ToDTO(payment));
            }
            catch (Exception ex) when (ex is BillingAlreadyPaidException
                   || ex is PaymentValueExceedsBillingValueException)
            {
                _logger.LogError($"Error doing payment. Exception Type: {ex}");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in creating payment: Exception: {ex}");
                return Problem("Something went wrong. Please check the app logs");
            }
        }
    }
}
