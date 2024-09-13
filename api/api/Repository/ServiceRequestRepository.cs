using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly DataContext _context;

        public ServiceRequestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllRequestsAsync()
        {
            return await _context.ServiceRequests.ToListAsync();
        }

        public async Task<ServiceRequest> GetRequestByIdAsync(int id)
        {
            return await _context.ServiceRequests.FindAsync(id);
        }

        public async Task<IEnumerable<ServiceRequest>> GetRequestsByClientIdAsync(int clientId)
        {
            return await _context.ServiceRequests.Where(sr => sr.ClientID == clientId).ToListAsync();
        }

        public async Task<IEnumerable<ServiceRequest>> GetRequestsByVendorIdAsync(int vendorId)
        {
            return await _context.ServiceRequests.Where(sr => sr.VendorID == vendorId).ToListAsync();
        }

        public async Task AddRequestAsync(ServiceRequest request)
        {
            await _context.ServiceRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRequestAsync(ServiceRequest request)
        {
            _context.ServiceRequests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestAsync(int id)
        {
            var request = await GetRequestByIdAsync(id);
            if (request != null)
            {
                _context.ServiceRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
