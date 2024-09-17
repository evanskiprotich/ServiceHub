using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        //public Task<User> RegisterClient(User user)
        //{
        //    return _clientRepository.CreateClient(user);
        //}

        //public Task<User> LoginClient(string email, string password)
        //{
        //    return _clientRepository.AuthenticateClient(email, password);
        //}

        public Task<IEnumerable<Service>> SearchServices(string query)
        {
            return _clientRepository.SearchServices(query);
        }

        public Task<ServiceRequest> RequestService(int clientId, int serviceId, ServiceRequest request)
        {
            return _clientRepository.RequestService(clientId, serviceId, request);
        }

        public Task<Payment> MakePayment(int clientId, Payment payment)
        {
            return _clientRepository.MakePayment(clientId, payment);
        }

        public Task<IEnumerable<ServiceRequest>> GetServiceHistory(int clientId)
        {
            return _clientRepository.GetServiceHistory(clientId);
        }

        public Task<string> GetServiceStatus(int clientId, int serviceRequestId)
        {
            return _clientRepository.GetServiceStatus(clientId, serviceRequestId);
        }

        public Task<bool> CancelServiceRequest(int clientId, int serviceRequestId)
        {
            return _clientRepository.CancelServiceRequest(clientId, serviceRequestId);
        }

        public Task<Review> LeaveReview(int clientId, int serviceId, Review review)
        {
            return _clientRepository.LeaveReview(clientId, serviceId, review);
        }

        public Task<ChatMessage> SendMessage(int clientId, int vendorId, ChatMessage message)
        {
            return _clientRepository.SendMessage(clientId, vendorId, message);
        }

        public Task<IEnumerable<ChatMessage>> GetChatMessages(int clientId, int vendorId)
        {
            return _clientRepository.GetChatMessages(clientId, vendorId);
        }

        public Task<User> UpdateClientProfile(int clientId, User user)
        {
            return _clientRepository.UpdateClientProfile(clientId, user);
        }

        public Task<IEnumerable<Notification>> GetClientNotifications(int clientId)
        {
            return _clientRepository.GetClientNotifications(clientId);
        }
    }
}
