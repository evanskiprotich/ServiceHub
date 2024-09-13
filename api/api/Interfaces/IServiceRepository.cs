using api.Dtos.Service;
using api.Models;

namespace api.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task<IEnumerable<Service>> GetServicesByVendorIdAsync(int vendorId);
        Task<List<ServiceDto>> GetNearbyServices(double userLat, double userLon);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}
