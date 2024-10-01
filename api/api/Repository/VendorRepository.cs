using api.Data;
using api.Dtos.ChatMessage;
using api.Dtos.Dispute;
using api.Dtos.Notification;
using api.Dtos.Payment;
using api.Dtos.Service;
using api.Dtos.ServiceRequest;
using api.Dtos.User;
using api.Dtos.Withdrawal;
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

        public async Task<IEnumerable<ServiceDto>> GetVendorServices(int vendorId)
        {
            return await _context.Services
                .Where(s => s.VendorID == vendorId)
                .Select(s => new ServiceDto
                {
                    ServiceID = s.ServiceID,
                    ServiceName = s.ServiceName,
                    ServiceDescription = s.ServiceDescription,
                    Cost = s.Cost,
                    IsAvailable = s.IsAvailable
                })
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

            // Populate ServiceID in the DTO
            serviceDto.ServiceID = service.ServiceID; 
            serviceDto.CreatedAt = service.CreatedAt; // Adding CreatedAt to the DTO if needed
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
            existingService.UpdatedAt = DateTime.UtcNow; 

            await _context.SaveChangesAsync();

            serviceDto.UpdatedAt = existingService.UpdatedAt; 
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

        public async Task<IEnumerable<ServiceRequestDto>> GetServiceRequests(int vendorId)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.Service.VendorID == vendorId)
                .Select(sr => new ServiceRequestDto
                {
                    RequestID = sr.RequestID,
                    ClientID = sr.ClientID,
                    ServiceID = sr.ServiceID,
                    Status = sr.Status,
                    RequestDate = sr.RequestDate
                })
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

        public async Task<PaymentDto> GetPaymentDetails(int vendorId, int requestId)
        {
            var payment = await _context.Payments
                .FirstOrDefaultAsync(p => p.RequestID == requestId && p.ServiceRequest.Service.VendorID == vendorId);

            if (payment == null) return null;

            return new PaymentDto
            {
                PaymentID = payment.PaymentID,
                Amount = payment.Amount,
                Status = payment.Status,
                PaidAt = payment.PaidAt
            };
        }

        public async Task<IEnumerable<PaymentDto>> GetVendorPayments(int vendorId)
        {
            return await _context.Payments
                .Where(p => p.ServiceRequest.Service.VendorID == vendorId)
                .Select(p => new PaymentDto
                {
                    PaymentID = p.PaymentID,
                    Amount = p.Amount,
                    Status = p.Status,
                    PaidAt = p.PaidAt
                })
                .ToListAsync();
        }

        public async Task<ChatMessageDto> SendMessage(int vendorId, int clientId, ChatMessageDto messageDto)
        {
            var message = new ChatMessage
            {
                SenderID = vendorId,
                ReceiverID = clientId,
                MessageText = messageDto.MessageText,
                SentAt = DateTime.UtcNow
            };

            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
            messageDto.MessageID = message.MessageID; // Add MessageID to DTO if needed
            return messageDto;
        }

        public async Task<IEnumerable<ChatMessageDto>> GetChatMessages(int vendorId, int clientId)
        {
            return await _context.ChatMessages
                .Where(cm => cm.SenderID == vendorId && cm.ReceiverID == clientId || cm.SenderID == clientId && cm.ReceiverID == vendorId)
                .OrderBy(cm => cm.SentAt)
                .Select(cm => new ChatMessageDto
                {
                    MessageID = cm.MessageID,
                    SenderID = cm.SenderID,
                    ReceiverID = cm.ReceiverID,
                    MessageText = cm.MessageText,
                    SentAt = cm.SentAt
                })
                .ToListAsync();
        }

        public async Task<UserDto> UpdateVendorProfile(int vendorId, UserDto vendorDto)
        {
            var existingVendor = await _context.Users.FirstOrDefaultAsync(u => u.UserID == vendorId);
            if (existingVendor == null) return null;

            existingVendor.UserName = vendorDto.UserName;
            existingVendor.Email = vendorDto.Email;
            // Note: Do not set Password directly without hashing it
            // existingVendor.Password = vendorDto.Password;

            await _context.SaveChangesAsync();
            vendorDto.UserID = existingVendor.UserID; // Add UserID to DTO if needed
            return vendorDto;
        }

        public async Task<IEnumerable<NotificationDto>> GetVendorNotifications(int vendorId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == vendorId && !n.IsRead)
                .OrderByDescending(n => n.SentAt)
                .Select(n => new NotificationDto
                {
                    NotificationID = n.Id,
                    Message = n.Message,
                    IsRead = n.IsRead,
                    SentAt = n.SentAt
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<DisputeDto>> GetVendorDisputes(int vendorId)
        {
            return await _context.Disputes
                .Where(d => d.VendorID == vendorId)
                .Select(d => new DisputeDto
                {
                    DisputeID = d.DisputeID,
                    Issue = d.Issue,
                    Status = d.Status,
                    CreatedAt = d.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<WithdrawalDto> RequestWithdrawal(int vendorId, WithdrawalDto withdrawalDto)
        {
            var withdrawal = new Withdrawal
            {
                VendorID = vendorId,
                Amount = withdrawalDto.Amount,
                Status = "Pending",
                WithdrawalDate = DateTime.UtcNow
            };

            _context.Withdrawals.Add(withdrawal);
            await _context.SaveChangesAsync();
            withdrawalDto.WithdrawalID = withdrawal.WithdrawalID; // Add WithdrawalID to DTO if needed
            return withdrawalDto;
        }

        public async Task<IEnumerable<WithdrawalDto>> GetWithdrawals(int vendorId)
        {
            return await _context.Withdrawals
                .Where(w => w.VendorID == vendorId)
                .Select(w => new WithdrawalDto
                {
                    WithdrawalID = w.WithdrawalID,
                    Amount = w.Amount,
                    Status = w.Status,
                    WithdrawalDate = w.WithdrawalDate
                })
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
