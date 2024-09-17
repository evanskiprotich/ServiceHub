using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentRepository paymentRepository, IPaymentService paymentService)
        {
            _paymentRepository = paymentRepository;
            _paymentService = paymentService;
        }

        // GET: api/payment
        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _paymentRepository.GetAllPaymentsAsync();
            return Ok(payments);
        }

        // POST: api/payment
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _paymentRepository.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentID }, payment);
        }

        // GET: api/payment/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        // POST: api/payment/initialize
        [HttpPost("initialize")]
        public async Task<IActionResult> InitiatePayment(decimal amount, string phoneNumber)
        {
            try
            {
                var response = await _paymentService.SendMoneyB2CAsync(amount, phoneNumber);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error initiating payment: {ex.Message}");
            }
        }
    }
}