using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        //public async Task<User> CreateClient(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();
        //    return user;
        //}

        //public async Task<User> AuthenticateClient(string email, string password)
        //{
        //    return await _context.Users
        //        .FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.Role == "Client");
        //}

        //public async Task<IEnumerable<Service>> GetServicesByLocation(string location)
        //{
        //    return await _context.Services
        //        .Where(s => s.Location == location && s.IsAvailable)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<Service>> SearchServices(string query)
        {
            return await _context.Services
                .Where(s => s.ServiceName.Contains(query) || s.ServiceDescription.Contains(query))
                .ToListAsync();
        }

        public async Task<ServiceRequest> RequestService(int clientId, int serviceId, ServiceRequest request)
        {
            request.ClientID = clientId;
            request.ServiceID = serviceId;
            _context.ServiceRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<Payment> MakePayment(int clientId, Payment payment)
        {
            payment.ClientID = clientId;
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetPaymentReceipts(int clientId)
        {
            return await _context.Payments
                .Where(p => p.ClientID == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceRequest>> GetServiceHistory(int clientId)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.ClientID == clientId)
                .ToListAsync();
        }

        public async Task<string> GetServiceStatus(int clientId, int serviceRequestId)
        {
            var request = await _context.ServiceRequests
                .FirstOrDefaultAsync(sr => sr.ClientID == clientId && sr.RequestID == serviceRequestId);
            return request?.Status;
        }

        public async Task<bool> CancelServiceRequest(int clientId, int serviceRequestId)
        {
            var request = await _context.ServiceRequests
                .FirstOrDefaultAsync(sr => sr.ClientID == clientId && sr.RequestID == serviceRequestId);

            if (request == null || request.Status != "Pending")
                return false;

            request.Status = "Cancelled";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Review> LeaveReview(int clientId, int serviceId, Review review)
        {
            review.ClientID = clientId;
            review.ServiceID = serviceId;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<ChatMessage> SendMessage(int clientId, int vendorId, ChatMessage message)
        {
            message.SenderID = clientId;
            message.ReceiverID = vendorId;
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<IEnumerable<ChatMessage>> GetChatMessages(int clientId, int vendorId)
        {
            return await _context.ChatMessages
                .Where(cm => cm.SenderID == clientId && cm.ReceiverID == vendorId || cm.SenderID == vendorId && cm.ReceiverID == clientId)
                .OrderBy(cm => cm.SentAt)
                .ToListAsync();
        }

        public async Task<User> UpdateClientProfile(int clientId, User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserID == clientId);
            if (existingUser == null) return null;

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<IEnumerable<Notification>> GetClientNotifications(int clientId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == clientId && !n.IsRead)
                .OrderByDescending(n => n.SentAt)
                .ToListAsync();
        }

        public async Task<Dispute> RaiseDispute(int clientId, int vendorId, int requestId, Dispute dispute)
        {
            dispute.ClientID = clientId;
            dispute.VendorID = vendorId;
            dispute.RequestID = requestId;
            dispute.Status = "Pending";
            dispute.CreatedAt = DateTime.UtcNow;

            _context.Disputes.Add(dispute);
            await _context.SaveChangesAsync();
            return dispute;
        }

        public async Task<IEnumerable<Dispute>> GetClientDisputes(int clientId)
        {
            return await _context.Disputes
                .Where(d => d.ClientID == clientId)
                .ToListAsync();
        }
    }
}
