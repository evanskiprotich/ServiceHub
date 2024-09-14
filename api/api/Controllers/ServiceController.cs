using api.Dtos.Service;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // GET: api/service
        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceRepository.GetAllServicesAsync();
            return Ok(services);
        }

        // GET: api/service/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceRepository.GetServiceByIdAsync(id);
            if (service == null) return NotFound();

            return Ok(service);
        }

        // GET: api/service/vendor/{vendorId}
        [HttpGet("vendor/{vendorId}")]
        public async Task<IActionResult> GetServicesByVendorId(int vendorId)
        {
            var services = await _serviceRepository.GetServicesByVendorIdAsync(vendorId);
            return Ok(services);
        }

        // POST: api/service
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] Service service)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _serviceRepository.AddServiceAsync(service);
            return CreatedAtAction(nameof(GetServiceById), new { id = service.ServiceID }, service);
        }

        // PUT: api/service/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] Service service)
        {
            if (id != service.ServiceID) return BadRequest("Service ID mismatch");

            var existingService = await _serviceRepository.GetServiceByIdAsync(id);
            if (existingService == null) return NotFound();

            await _serviceRepository.UpdateServiceAsync(service);
            return NoContent();
        }

        // DELETE: api/service/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _serviceRepository.GetServiceByIdAsync(id);
            if (service == null) return NotFound();

            await _serviceRepository.DeleteServiceAsync(id);
            return NoContent();
        }

        // GET: api/service/nearby
        [HttpGet("nearby")]
        [AllowAnonymous] // Allow users without authentication
        public async Task<IActionResult> GetNearbyServices(double latitude, double longitude)
        {
            var services = await _serviceRepository.GetNearbyServices(latitude, longitude);
            return Ok(services);
        }
    }
}
