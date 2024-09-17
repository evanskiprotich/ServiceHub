using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly DataContext _context;

        public VendorRepository(DataContext context)
        {
            _context = context;
        }

        //public async Task<User> CreateVendor(User vendor)
        //{
        //    _context.Users.Add(vendor);
        //    await _context.SaveChangesAsync();
        //    return vendor;
        //}

        //public async Task<User> AuthenticateVendor(string email, string password)
        //{
        //    return await _context.Users
        //        .FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.Role == "Vendor");
        //}

        public async Task<IEnumerable<Service>> GetVendorServices(int vendorId)
        {
            return await _context.Services
                .Where(s => s.VendorID == vendorId)
                .ToListAsync();
        }

        public async Task<Service> AddService(int vendorId, Service service)
        {
            service.VendorID = vendorId;
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service> UpdateService(int vendorId, int serviceId, Service service)
        {
            var existingService = await _context.Services
                .FirstOrDefaultAsync(s => s.VendorID == vendorId && s.ServiceID == serviceId);

            if (existingService == null) return null;

            existingService.ServiceName = service.ServiceName;
            existingService.ServiceDescription = service.ServiceDescription;
            existingService.Cost = service.Cost;
            existingService.IsAvailable = service.IsAvailable;

            await _context.SaveChangesAsync();
            return existingService;
        }

        public async Task<bool> RemoveService(int vendorId, int serviceId)
        {
            var service = await _context.Services
                .FirstOrDefaultAsync(s => s.VendorID == vendorId && s.ServiceID == serviceId);

            if (service == null) return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceRequest>> GetServiceRequests(int vendorId)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.Service.VendorID == vendorId)
                .ToListAsync();
        }

        public async Task<bool> AcceptServiceRequest(int vendorId, int requestId)
        {
            var request = await _context.ServiceRequests
                .FirstOrDefaultAsync(sr => sr.RequestID == requestId && sr.Service.VendorID == vendorId);

            if (request == null || request.Status != "Pending") return false;

            request.Status = "Accepted";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectServiceRequest(int vendorId, int requestId)
        {
            var request = await _context.ServiceRequests
                .FirstOrDefaultAsync(sr => sr.RequestID == requestId && sr.Service.VendorID == vendorId);

            if (request == null || request.Status != "Pending") return false;

            request.Status = "Rejected";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Payment> GetPaymentDetails(int vendorId, int requestId)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(p => p.RequestID == requestId && p.ServiceRequest.Service.VendorID == vendorId);
        }

        public async Task<IEnumerable<Payment>> GetVendorPayments(int vendorId)
        {
            return await _context.Payments
                .Where(p => p.ServiceRequest.Service.VendorID == vendorId)
                .ToListAsync();
        }

        public async Task<ChatMessage> SendMessage(int vendorId, int clientId, ChatMessage message)
        {
            message.SenderID = vendorId;
            message.ReceiverID = clientId;
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<IEnumerable<ChatMessage>> GetChatMessages(int vendorId, int clientId)
        {
            return await _context.ChatMessages
                .Where(cm => cm.SenderID == vendorId && cm.ReceiverID == clientId || cm.SenderID == clientId && cm.ReceiverID == vendorId)
                .OrderBy(cm => cm.SentAt)
                .ToListAsync();
        }

        public async Task<User> UpdateVendorProfile(int vendorId, User vendor)
        {
            var existingVendor = await _context.Users.FirstOrDefaultAsync(u => u.UserID == vendorId);
            if (existingVendor == null) return null;

            existingVendor.UserName = vendor.UserName;
            existingVendor.Email = vendor.Email;
            existingVendor.Password = vendor.Password;

            await _context.SaveChangesAsync();
            return existingVendor;
        }

        public async Task<IEnumerable<Notification>> GetVendorNotifications(int vendorId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == vendorId && !n.IsRead)
                .OrderByDescending(n => n.SentAt)
                .ToListAsync();
        }
    }
}
