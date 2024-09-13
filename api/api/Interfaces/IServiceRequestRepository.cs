using api.Models;

namespace api.Interfaces
{
    public interface IServiceRequestRepository
    {
        Task<IEnumerable<ServiceRequest>> GetAllRequestsAsync();
        Task<ServiceRequest> GetRequestByIdAsync(int id);
        Task<IEnumerable<ServiceRequest>> GetRequestsByClientIdAsync(int clientId);
        Task<IEnumerable<ServiceRequest>> GetRequestsByVendorIdAsync(int vendorId);
        Task AddRequestAsync(ServiceRequest request);
        Task UpdateRequestAsync(ServiceRequest request);
        Task DeleteRequestAsync(int id);
    }
}
