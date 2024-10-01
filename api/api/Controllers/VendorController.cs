using api.Dtos.Service;
using api.Dtos.Notification;
using api.Dtos.Payment;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos.ChatMessage;
using api.Dtos.User;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Vendor")]
    public class VendorController : ControllerBase
    {
        private readonly VendorService _vendorService;

        public VendorController(VendorService vendorService)
        {
            _vendorService = vendorService;
        }

        // [HttpPost("register")]
        // public async Task<IActionResult> RegisterVendor([FromBody] UserDto vendorDto)
        // {
        //     var newVendor = await _vendorService.RegisterVendor(vendorDto);
        //     return Ok(newVendor);
        // }

        // [HttpPost("login")]
        // public async Task<IActionResult> LoginVendor([FromBody] LoginModel loginModel)
        // {
        //     var vendor = await _vendorService.LoginVendor(loginModel.Email, loginModel.Password);
        //     if (vendor == null)
        //         return Unauthorized();

        //     return Ok(vendor);
        // }

        [HttpGet("services")]
        public async Task<IActionResult> GetVendorServices()
        {
            int vendorId = GetVendorIdFromClaims();
            var services = await _vendorService.GetVendorServices(vendorId);
            return Ok(services);
        }

        [HttpPost("add-service")]
        public async Task<IActionResult> AddService([FromBody] ServiceCreateDto serviceDto)
        {
            int vendorId = GetVendorIdFromClaims();
            var newService = await _vendorService.AddService(vendorId, serviceDto);
            return Ok(newService);
        }

        [HttpPut("update-service/{serviceId}")]
        public async Task<IActionResult> UpdateService(int serviceId, [FromBody] ServiceUpdateDto serviceDto)
        {
            int vendorId = GetVendorIdFromClaims();
            var updatedService = await _vendorService.UpdateService(vendorId, serviceId, serviceDto);
            return Ok(updatedService);
        }

        [HttpDelete("remove-service/{serviceId}")]
        public async Task<IActionResult> RemoveService(int serviceId)
        {
            int vendorId = GetVendorIdFromClaims();
            var success = await _vendorService.RemoveService(vendorId, serviceId);
            return Ok(success);
        }

        [HttpGet("service-requests")]
        public async Task<IActionResult> GetServiceRequests()
        {
            int vendorId = GetVendorIdFromClaims();
            var serviceRequests = await _vendorService.GetServiceRequests(vendorId);
            return Ok(serviceRequests);
        }

        [HttpPost("accept-request/{requestId}")]
        public async Task<IActionResult> AcceptServiceRequest(int requestId)
        {
            int vendorId = GetVendorIdFromClaims();
            var success = await _vendorService.AcceptServiceRequest(vendorId, requestId);
            return Ok(success);
        }

        [HttpPost("reject-request/{requestId}")]
        public async Task<IActionResult> RejectServiceRequest(int requestId)
        {
            int vendorId = GetVendorIdFromClaims();
            var success = await _vendorService.RejectServiceRequest(vendorId, requestId);
            return Ok(success);
        }

        [HttpGet("payment-details/{requestId}")]
        public async Task<IActionResult> GetPaymentDetails(int requestId)
        {
            int vendorId = GetVendorIdFromClaims();
            var payment = await _vendorService.GetPaymentDetails(vendorId, requestId);
            return Ok(payment);
        }

        [HttpGet("payments")]
        public async Task<IActionResult> GetVendorPayments()
        {
            int vendorId = GetVendorIdFromClaims();
            var payments = await _vendorService.GetVendorPayments(vendorId);
            return Ok(payments);
        }

        [HttpPost("send-message/{clientId}")]
        public async Task<IActionResult> SendMessage(int clientId, [FromBody] ChatMessageDto messageDto)
        {
            int vendorId = GetVendorIdFromClaims();
            var newMessage = await _vendorService.SendMessage(vendorId, clientId, messageDto);
            return Ok(newMessage);
        }

        [HttpGet("chat-messages/{clientId}")]
        public async Task<IActionResult> GetChatMessages(int clientId)
        {
            int vendorId = GetVendorIdFromClaims();
            var messages = await _vendorService.GetChatMessages(vendorId, clientId);
            return Ok(messages);
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UserDto vendorDto)
        {
            int vendorId = GetVendorIdFromClaims();
            var updatedVendor = await _vendorService.UpdateVendorProfile(vendorId, vendorDto);
            return Ok(updatedVendor);
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotifications()
        {
            int vendorId = GetVendorIdFromClaims();
            var notifications = await _vendorService.GetVendorNotifications(vendorId);
            return Ok(notifications);
        }

        // Helper method to extract vendor ID from claims
        private int GetVendorIdFromClaims()
        {
            // Assuming the vendor ID is stored in the claims. Modify according to your implementation.
            var vendorIdClaim = User.FindFirst("VendorId")?.Value;
            return int.Parse(vendorIdClaim);
        }
    }
}
