using api.Models;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAdmin([FromBody] User admin)
        {
            var newAdmin = await _adminService.RegisterAdmin(admin);
            return Ok(newAdmin);
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> LoginAdmin([FromBody] LoginModel loginModel)
        //{
        //    var admin = await _adminService.LoginAdmin(loginModel.Email, loginModel.Password);
        //    if (admin == null)
        //        return Unauthorized();

        //    return Ok(admin);
        //}

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsers();
            return Ok(users);
        }

        [HttpDelete("delete-user/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var success = await _adminService.DeleteUser(userId);
            if (!success) return NotFound();

            return Ok();
        }

        [HttpGet("services")]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _adminService.GetAllServices();
            return Ok(services);
        }

        [HttpDelete("delete-service/{serviceId}")]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            var success = await _adminService.DeleteService(serviceId);
            if (!success) return NotFound();

            return Ok();
        }

        [HttpGet("service-requests")]
        public async Task<IActionResult> GetAllServiceRequests()
        {
            var serviceRequests = await _adminService.GetAllServiceRequests();
            return Ok(serviceRequests);
        }

        [HttpGet("payments")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _adminService.GetAllPayments();
            return Ok(payments);
        }
    }
}
