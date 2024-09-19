using api.Data;
using api.Dtos.Service;
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

        public async Task<ServiceCreateDto> AddService(int vendorId, ServiceCreateDto serviceDto)
        {
            var service = new Service
            {
                VendorID = vendorId,
                ServiceName = serviceDto.ServiceName,
                ServiceDescription = serviceDto.ServiceDescription,
                Cost = serviceDto.Cost,
                CreatedAt = DateTime.UtcNow,
                IsAvailable = serviceDto.IsAvailable
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return serviceDto;
        }

        public async Task<ServiceUpdateDto> UpdateService(int vendorId, int serviceId, ServiceUpdateDto serviceDto)
        {
            var existingService = await _context.Services
                .FirstOrDefaultAsync(s => s.VendorID == vendorId && s.ServiceID == serviceId);

            if (existingService == null) return null;

            existingService.ServiceName = serviceDto.ServiceName;
            existingService.ServiceDescription = serviceDto.ServiceDescription;
            existingService.Cost = serviceDto.Cost;
            existingService.IsAvailable = serviceDto.IsAvailable;

            await _context.SaveChangesAsync();

            return serviceDto;
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

        public async Task<IEnumerable<Dispute>> GetVendorDisputes(int vendorId)
        {
            return await _context.Disputes
                .Where(d => d.VendorID == vendorId)
                .ToListAsync();
        }

        public async Task<Withdrawal> RequestWithdrawal(int vendorId, Withdrawal withdrawal)
        {
            withdrawal.VendorID = vendorId;
            withdrawal.Status = "Pending";
            withdrawal.WithdrawalDate = DateTime.UtcNow;

            _context.Withdrawals.Add(withdrawal);
            await _context.SaveChangesAsync();
            return withdrawal;
        }

        public async Task<IEnumerable<Withdrawal>> GetWithdrawals(int vendorId)
        {
            return await _context.Withdrawals
                .Where(w => w.VendorID == vendorId)
                .ToListAsync();
        }

        public async Task<bool> ResolveDispute(int vendorId, int disputeId, string resolution)
        {
            var dispute = await _context.Disputes
                .FirstOrDefaultAsync(d => d.DisputeID == disputeId && d.VendorID == vendorId);

            if (dispute == null || dispute.Status != "Pending") return false;

            dispute.Status = "Resolved";
            dispute.Resolution = resolution;
            dispute.ResolvedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
