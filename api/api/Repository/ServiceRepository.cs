using api.Data;
using api.Dtos.Service;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<IEnumerable<Service>> GetServicesByVendorIdAsync(int vendorId)
        {
            return await _context.Services.Where(s => s.VendorID == vendorId).ToListAsync();
        }

        public async Task AddServiceAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await GetServiceByIdAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }

        // find services based on user location
        public async Task<List<ServiceDto>> GetNearbyServices(double userLat, double userLon)
        {
            var vendors = await _context.Users
                .Where(u => u.RoleID == 3)
                .ToListAsync();

            // Calculate distances for each vendor based on user location and return vendors within 10 km radius
            var nearbyVendors = vendors.Where(v =>
            {
                // Check if both Latitude and Longitude are not null
                if (v.Latitude.HasValue && v.Longitude.HasValue)
                {
                    double distance = GetDistance(userLat, userLon, v.Longitude.Value, v.Latitude.Value);
                    return distance <= 10; // 10 km radius
                }
                return false; // Skip vendors with null coordinates
            }).ToList();

            var services = await _context.Services
                .Where(s => nearbyVendors.Select(v => v.UserID).Contains(s.VendorID))
                .ToListAsync();

            return services.Select(s => new ServiceDto
            {
                ServiceID = s.ServiceID,
                ServiceName = s.ServiceName,
                ServiceDescription = s.ServiceDescription,
                Cost = s.Cost
            }).ToList();
        }

        // Haversine formula to calculate distance between two lat/long points
        private double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371; // Radius of the earth in km
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c; // Distance in km
            return distance;
        }

        private double ToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}
