using api.Dtos.Service;
using api.Models;

namespace api.Interfaces
{
    public interface IVendorRepository
    {
        //Task<User> CreateVendor(User vendor);
        //Task<User> AuthenticateVendor(string email, string password);

        Task<IEnumerable<Service>> GetVendorServices(int vendorId);
        Task<ServiceCreateDto> AddService(int vendorId, ServiceCreateDto serviceDto);
        Task<ServiceUpdateDto> UpdateService(int vendorId, int serviceId, ServiceUpdateDto serviceDto);
        Task<bool> RemoveService(int vendorId, int serviceId);

        Task<IEnumerable<ServiceRequest>> GetServiceRequests(int vendorId);
        Task<bool> AcceptServiceRequest(int vendorId, int requestId);
        Task<bool> RejectServiceRequest(int vendorId, int requestId);

        Task<Payment> GetPaymentDetails(int vendorId, int requestId);
        Task<IEnumerable<Payment>> GetVendorPayments(int vendorId);

        Task<ChatMessage> SendMessage(int vendorId, int clientId, ChatMessage message);
        Task<IEnumerable<ChatMessage>> GetChatMessages(int vendorId, int clientId);

        Task<User> UpdateVendorProfile(int vendorId, User vendor);
        Task<IEnumerable<Notification>> GetVendorNotifications(int vendorId);

        Task<IEnumerable<Dispute>> GetVendorDisputes(int vendorId);
        Task<Withdrawal> RequestWithdrawal(int vendorId, Withdrawal withdrawal);
        Task<IEnumerable<Withdrawal>> GetWithdrawals(int vendorId);
        Task<bool> ResolveDispute(int vendorId, int disputeId, string resolution);
    }
}
