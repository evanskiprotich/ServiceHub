using api.Data;
using api.Interfaces;
using api.Models;
using api.Dtos;
using api.Dtos.ChatMessage;
using api.Dtos.Dispute;
using api.Dtos.Notification;
using api.Dtos.Payment;
using api.Dtos.Review;
using api.Dtos.Service;
using api.Dtos.ServiceRequest;
using api.Dtos.User; // Assuming your DTOs are in this namespace
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Replacing User with UserDto
        public async Task<UserDto> UpdateClientProfile(int clientId, UserUpdateDto userUpdateDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserID == clientId);
            if (existingUser == null) return null;

            // Map changes from the DTO to the existing entity
            _mapper.Map(userUpdateDto, existingUser);

            await _context.SaveChangesAsync();

            // Return the updated user as a DTO
            return _mapper.Map<UserDto>(existingUser);
        }

        public async Task<IEnumerable<ServiceDto>> SearchServices(string query)
        {
            var services = await _context.Services
                .Where(s => s.ServiceName.Contains(query) || s.ServiceDescription.Contains(query))
                .ToListAsync();

            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceRequestDto> RequestService(int clientId, int serviceId, ServiceRequestCreateDto requestDto)
        {
            var request = _mapper.Map<ServiceRequest>(requestDto);
            request.ClientID = clientId;
            request.ServiceID = serviceId;

            _context.ServiceRequests.Add(request);
            await _context.SaveChangesAsync();

            return _mapper.Map<ServiceRequestDto>(request);
        }

        public async Task<PaymentDto> MakePayment(int clientId, PaymentCreateDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            payment.ClientID = clientId;

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentReceipts(int clientId)
        {
            var payments = await _context.Payments
                .Where(p => p.ClientID == clientId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<IEnumerable<ServiceRequestDto>> GetServiceHistory(int clientId)
        {
            var serviceRequests = await _context.ServiceRequests
                .Where(sr => sr.ClientID == clientId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ServiceRequestDto>>(serviceRequests);
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

        public async Task<ReviewDto> LeaveReview(int clientId, int serviceId, ReviewCreateDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            review.ClientID = clientId;
            review.ServiceID = serviceId;

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<ChatMessageDto> SendMessage(int clientId, int vendorId, ChatMessageCreateDto messageDto)
        {
            var message = _mapper.Map<ChatMessage>(messageDto);
            message.SenderID = clientId;
            message.ReceiverID = vendorId;

            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();

            return _mapper.Map<ChatMessageDto>(message);
        }

        public async Task<IEnumerable<ChatMessageDto>> GetChatMessages(int clientId, int vendorId)
        {
            var messages = await _context.ChatMessages
                .Where(cm => (cm.SenderID == clientId && cm.ReceiverID == vendorId) || 
                             (cm.SenderID == vendorId && cm.ReceiverID == clientId))
                .OrderBy(cm => cm.SentAt)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ChatMessageDto>>(messages);
        }

        public async Task<IEnumerable<NotificationDto>> GetClientNotifications(int clientId)
        {
            var notifications = await _context.Notifications
                .Where(n => n.UserId == clientId && !n.IsRead)
                .OrderByDescending(n => n.SentAt)
                .ToListAsync();

            return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
        }

        public async Task<DisputeDto> RaiseDispute(int clientId, int vendorId, int requestId, DisputeCreateDto disputeDto)
        {
            var dispute = _mapper.Map<Dispute>(disputeDto);
            dispute.ClientID = clientId;
            dispute.VendorID = vendorId;
            dispute.RequestID = requestId;
            dispute.Status = "Pending";
            dispute.CreatedAt = DateTime.UtcNow;

            _context.Disputes.Add(dispute);
            await _context.SaveChangesAsync();

            return _mapper.Map<DisputeDto>(dispute);
        }

        public async Task<IEnumerable<DisputeDto>> GetClientDisputes(int clientId)
        {
            var disputes = await _context.Disputes
                .Where(d => d.ClientID == clientId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<DisputeDto>>(disputes);
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
