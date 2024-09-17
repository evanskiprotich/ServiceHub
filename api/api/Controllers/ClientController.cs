using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles="Client")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> RegisterClient([FromBody] User user)
        //{
        //    var newUser = await _clientService.RegisterClient(user);
        //    return Ok(newUser);
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> LoginClient([FromBody] LoginModel loginModel)
        //{
        //    var client = await _clientService.LoginClient(loginModel.Email, loginModel.Password);
        //    if (client == null)
        //        return Unauthorized();

        //    return Ok(client);
        //}

        [HttpPost("request-service")]
        public async Task<IActionResult> RequestService(int clientId, int serviceId, [FromBody] ServiceRequest request)
        {
            var newRequest = await _clientService.RequestService(clientId, serviceId, request);
            return Ok(newRequest);
        }

        [HttpPost("make-payment")]
        public async Task<IActionResult> MakePayment(int clientId, [FromBody] Payment payment)
        {
            var newPayment = await _clientService.MakePayment(clientId, payment);
            return Ok(newPayment);
        }

        [HttpGet("service-history")]
        public async Task<IActionResult> GetServiceHistory(int clientId)
        {
            var history = await _clientService.GetServiceHistory(clientId);
            return Ok(history);
        }

        [HttpGet("service-status/{serviceRequestId}")]
        public async Task<IActionResult> GetServiceStatus(int clientId, int serviceRequestId)
        {
            var status = await _clientService.GetServiceStatus(clientId, serviceRequestId);
            return Ok(status);
        }

        [HttpPost("cancel-request/{serviceRequestId}")]
        public async Task<IActionResult> CancelServiceRequest(int clientId, int serviceRequestId)
        {
            var success = await _clientService.CancelServiceRequest(clientId, serviceRequestId);
            return Ok(success);
        }

        [HttpPost("leave-review/{serviceId}")]
        public async Task<IActionResult> LeaveReview(int clientId, int serviceId, [FromBody] Review review)
        {
            var newReview = await _clientService.LeaveReview(clientId, serviceId, review);
            return Ok(newReview);
        }

        [HttpPost("send-message/{vendorId}")]
        public async Task<IActionResult> SendMessage(int clientId, int vendorId, [FromBody] ChatMessage message)
        {
            var newMessage = await _clientService.SendMessage(clientId, vendorId, message);
            return Ok(newMessage);
        }

        [HttpGet("chat-messages/{vendorId}")]
        public async Task<IActionResult> GetChatMessages(int clientId, int vendorId)
        {
            var messages = await _clientService.GetChatMessages(clientId, vendorId);
            return Ok(messages);
        }

        [HttpPost("update-profile")]
        public async Task<IActionResult> UpdateProfile(int clientId, [FromBody] User user)
        {
            var updatedUser = await _clientService.UpdateClientProfile(clientId, user);
            return Ok(updatedUser);
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotifications(int clientId)
        {
            var notifications = await _clientService.GetClientNotifications(clientId);
            return Ok(notifications);
        }
    }
}
