using api.Dtos.Service;
using api.Dtos.ChatMessage;
using api.Dtos.Payment;
using api.Dtos.Notification;
using api.Dtos.Dispute;
using api.Dtos.ServiceRequest;
using api.Dtos.User;
using api.Dtos.Withdrawal;
using api.Models;

namespace api.Interfaces
{
    public interface IVendorRepository
    {
        // Task<User> CreateVendor(User vendor);
        // Task<User> AuthenticateVendor(string email, string password);

        Task<IEnumerable<ServiceDto>> GetVendorServices(int vendorId);
        Task<ServiceCreateDto> AddService(int vendorId, ServiceCreateDto serviceDto);
        Task<ServiceUpdateDto> UpdateService(int vendorId, int serviceId, ServiceUpdateDto serviceDto);
        Task<bool> RemoveService(int vendorId, int serviceId);

        Task<IEnumerable<ServiceRequestDto>> GetServiceRequests(int vendorId);
        Task<bool> AcceptServiceRequest(int vendorId, int requestId);
        Task<bool> RejectServiceRequest(int vendorId, int requestId);

        Task<PaymentDto> GetPaymentDetails(int vendorId, int requestId);
        Task<IEnumerable<PaymentDto>> GetVendorPayments(int vendorId);

        Task<ChatMessageDto> SendMessage(int vendorId, int clientId, ChatMessageDto messageDto);
        Task<IEnumerable<ChatMessageDto>> GetChatMessages(int vendorId, int clientId);

        Task<UserDto> UpdateVendorProfile(int vendorId, UserDto vendorDto);
        Task<IEnumerable<NotificationDto>> GetVendorNotifications(int vendorId);

        Task<IEnumerable<DisputeDto>> GetVendorDisputes(int vendorId);
        Task<WithdrawalDto> RequestWithdrawal(int vendorId, WithdrawalDto withdrawalDto);
        Task<IEnumerable<WithdrawalDto>> GetWithdrawals(int vendorId);
        Task<bool> ResolveDispute(int vendorId, int disputeId, string resolution);
    }
}