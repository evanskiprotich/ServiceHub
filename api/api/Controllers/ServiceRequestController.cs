using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;

        public ServiceRequestController(IServiceRequestRepository serviceRequestRepository)
        {
            _serviceRequestRepository = serviceRequestRepository;
        }

        // GET: api/servicerequest
        [HttpGet]
        public async Task<IActionResult> GetAllRequests()
        {
            var requests = await _serviceRequestRepository.GetAllRequestsAsync();
            return Ok(requests);
        }

        // GET: api/servicerequest/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            var request = await _serviceRequestRepository.GetRequestByIdAsync(id);
            if (request == null) return NotFound();

            return Ok(request);
        }

        // GET: api/servicerequest/client/{clientId}
        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetRequestsByClientId(int clientId)
        {
            var requests = await _serviceRequestRepository.GetRequestsByClientIdAsync(clientId);
            return Ok(requests);
        }

        // GET: api/servicerequest/vendor/{vendorId}
        [HttpGet("vendor/{vendorId}")]
        public async Task<IActionResult> GetRequestsByVendorId(int vendorId)
        {
            var requests = await _serviceRequestRepository.GetRequestsByVendorIdAsync(vendorId);
            return Ok(requests);
        }

        // POST: api/servicerequest
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] ServiceRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _serviceRequestRepository.AddRequestAsync(request);
            return CreatedAtAction(nameof(GetRequestById), new { id = request.RequestID }, request);
        }

        // PUT: api/servicerequest/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, [FromBody] ServiceRequest request)
        {
            if (id != request.RequestID) return BadRequest("Service Request ID mismatch");

            var existingRequest = await _serviceRequestRepository.GetRequestByIdAsync(id);
            if (existingRequest == null) return NotFound();

            await _serviceRequestRepository.UpdateRequestAsync(request);
            return NoContent();
        }

        // DELETE: api/servicerequest/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _serviceRequestRepository.GetRequestByIdAsync(id);
            if (request == null) return NotFound();

            await _serviceRequestRepository.DeleteRequestAsync(id);
            return NoContent();
        }
    }
}
