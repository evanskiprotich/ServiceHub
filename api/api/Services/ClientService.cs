using api.Interfaces;
using api.Dtos;
using api.Dtos.ChatMessage;
using api.Dtos.Dispute;
using api.Dtos.Notification;
using api.Dtos.Payment;
using api.Dtos.Review;
using api.Dtos.Service;
using api.Dtos.ServiceRequest;
using api.Dtos.User;

namespace api.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<IEnumerable<ServiceDto>> SearchServices(string query)
        {
            return _clientRepository.SearchServices(query);
        }

        public Task<ServiceRequestDto> RequestService(int clientId, int serviceId, ServiceRequestCreateDto requestDto)
        {
            return _clientRepository.RequestService(clientId, serviceId, requestDto);
        }

        public Task<PaymentDto> MakePayment(int clientId, PaymentCreateDto paymentDto)
        {
            return _clientRepository.MakePayment(clientId, paymentDto);
        }

        public Task<IEnumerable<PaymentDto>> GetPaymentReceipts(int clientId)
        {
            return _clientRepository.GetPaymentReceipts(clientId);
        }

        public Task<IEnumerable<ServiceRequestDto>> GetServiceHistory(int clientId)
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

        public Task<ReviewDto> LeaveReview(int clientId, int serviceId, ReviewCreateDto reviewDto)
        {
            return _clientRepository.LeaveReview(clientId, serviceId, reviewDto);
        }

        public Task<ChatMessageDto> SendMessage(int clientId, int vendorId, ChatMessageCreateDto messageDto)
        {
            return _clientRepository.SendMessage(clientId, vendorId, messageDto);
        }

        public Task<IEnumerable<ChatMessageDto>> GetChatMessages(int clientId, int vendorId)
        {
            return _clientRepository.GetChatMessages(clientId, vendorId);
        }

        public Task<UserDto> UpdateClientProfile(int clientId, UserUpdateDto userUpdateDto)
        {
            return _clientRepository.UpdateClientProfile(clientId, userUpdateDto);
        }

        public Task<IEnumerable<NotificationDto>> GetClientNotifications(int clientId)
        {
            return _clientRepository.GetClientNotifications(clientId);
        }

        public Task<DisputeDto> RaiseDispute(int clientId, int vendorId, int requestId, DisputeCreateDto disputeDto)
        {
            return _clientRepository.RaiseDispute(clientId, vendorId, requestId, disputeDto);
        }

        public Task<IEnumerable<DisputeDto>> GetClientDisputes(int clientId)
        {
            return _clientRepository.GetClientDisputes(clientId);
        }
        
        public Task<List<ServiceDto>> GetNearbyServices(double userLat, double userLon)
        {
            return _clientRepository.GetNearbyServices(userLat, userLon);
        }
    }
}
