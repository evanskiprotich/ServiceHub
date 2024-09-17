using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Vendor")]
    public class VendorController : ControllerBase
    {
        private readonly VendorService _vendorService;

        public VendorController(VendorService vendorService)
        {
            _vendorService = vendorService;
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> RegisterVendor([FromBody] User vendor)
        //{
        //    var newVendor = await _vendorService.RegisterVendor(vendor);
        //    return Ok(newVendor);
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> LoginVendor([FromBody] LoginModel loginModel)
        //{
        //    var vendor = await _vendorService.LoginVendor(loginModel.Email, loginModel.Password);
        //    if (vendor == null)
        //        return Unauthorized();

        //    return Ok(vendor);
        //}

        [HttpGet("services")]
        public async Task<IActionResult> GetVendorServices(int vendorId)
        {
            var services = await _vendorService.GetVendorServices(vendorId);
            return Ok(services);
        }

        [HttpPost("add-service")]
        public async Task<IActionResult> AddService(int vendorId, [FromBody] Service service)
        {
            var newService = await _vendorService.AddService(vendorId, service);
            return Ok(newService);
        }

        [HttpPut("update-service/{serviceId}")]
        public async Task<IActionResult> UpdateService(int vendorId, int serviceId, [FromBody] Service service)
        {
            var updatedService = await _vendorService.UpdateService(vendorId, serviceId, service);
            return Ok(updatedService);
        }

        [HttpDelete("remove-service/{serviceId}")]
        public async Task<IActionResult> RemoveService(int vendorId, int serviceId)
        {
            var success = await _vendorService.RemoveService(vendorId, serviceId);
            return Ok(success);
        }

        [HttpGet("service-requests")]
        public async Task<IActionResult> GetServiceRequests(int vendorId)
        {
            var serviceRequests = await _vendorService.GetServiceRequests(vendorId);
            return Ok(serviceRequests);
        }

        [HttpPost("accept-request/{requestId}")]
        public async Task<IActionResult> AcceptServiceRequest(int vendorId, int requestId)
        {
            var success = await _vendorService.AcceptServiceRequest(vendorId, requestId);
            return Ok(success);
        }

        [HttpPost("reject-request/{requestId}")]
        public async Task<IActionResult> RejectServiceRequest(int vendorId, int requestId)
        {
            var success = await _vendorService.RejectServiceRequest(vendorId, requestId);
            return Ok(success);
        }

        [HttpGet("payment-details/{requestId}")]
        public async Task<IActionResult> GetPaymentDetails(int vendorId, int requestId)
        {
            var payment = await _vendorService.GetPaymentDetails(vendorId, requestId);
            return Ok(payment);
        }

        [HttpGet("payments")]
        public async Task<IActionResult> GetVendorPayments(int vendorId)
        {
            var payments = await _vendorService.GetVendorPayments(vendorId);
            return Ok(payments);
        }

        [HttpPost("send-message/{clientId}")]
        public async Task<IActionResult> SendMessage(int vendorId, int clientId, [FromBody] ChatMessage message)
        {
            var newMessage = await _vendorService.SendMessage(vendorId, clientId, message);
            return Ok(newMessage);
        }

        [HttpGet("chat-messages/{clientId}")]
        public async Task<IActionResult> GetChatMessages(int vendorId, int clientId)
        {
            var messages = await _vendorService.GetChatMessages(vendorId, clientId);
            return Ok(messages);
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile(int vendorId, [FromBody] User vendor)
        {
            var updatedVendor = await _vendorService.UpdateVendorProfile(vendorId, vendor);
            return Ok(updatedVendor);
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotifications(int vendorId)
        {
            var notifications = await _vendorService.GetVendorNotifications(vendorId);
            return Ok(notifications);
        }
    }
}
