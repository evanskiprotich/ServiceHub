using api.Models;

namespace api.Interfaces
{
    public interface IClientRepository
    {
        //Task<User> CreateClient(User user);
        //Task<User> AuthenticateClient(string email, string password);

        //Task<IEnumerable<Service>> GetServicesByLocation(string location);
        Task<IEnumerable<Service>> SearchServices(string query);
        Task<ServiceRequest> RequestService(int clientId, int serviceId, ServiceRequest request);

        Task<Payment> MakePayment(int clientId, Payment payment);
        Task<IEnumerable<Payment>> GetPaymentReceipts(int clientId);

        Task<IEnumerable<ServiceRequest>> GetServiceHistory(int clientId);
        Task<string> GetServiceStatus(int clientId, int serviceRequestId);
        Task<bool> CancelServiceRequest(int clientId, int serviceRequestId);

        Task<Review> LeaveReview(int clientId, int serviceId, Review review);

        Task<ChatMessage> SendMessage(int clientId, int vendorId, ChatMessage message);
        Task<IEnumerable<ChatMessage>> GetChatMessages(int clientId, int vendorId);

        Task<User> UpdateClientProfile(int clientId, User user);
        Task<IEnumerable<Notification>> GetClientNotifications(int clientId);
    }
}
