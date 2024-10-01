using api.Dtos;
using api.Dtos.ChatMessage;
using api.Dtos.Dispute;
using api.Dtos.Notification;
using api.Dtos.Payment;
using api.Dtos.Review;
using api.Dtos.Service;
using api.Dtos.ServiceRequest;
using api.Dtos.User;

namespace api.Interfaces
{
    public interface IClientRepository
    {
        Task<UserDto> UpdateClientProfile(int clientId, UserUpdateDto userUpdateDto);

        Task<IEnumerable<ServiceDto>> SearchServices(string query);

        Task<ServiceRequestDto> RequestService(int clientId, int serviceId, ServiceRequestCreateDto requestDto);

        Task<PaymentDto> MakePayment(int clientId, PaymentCreateDto paymentDto);

        Task<IEnumerable<PaymentDto>> GetPaymentReceipts(int clientId);

        Task<IEnumerable<ServiceRequestDto>> GetServiceHistory(int clientId);

        Task<string> GetServiceStatus(int clientId, int serviceRequestId);

        Task<bool> CancelServiceRequest(int clientId, int serviceRequestId);

        Task<ReviewDto> LeaveReview(int clientId, int serviceId, ReviewCreateDto reviewDto);

        Task<ChatMessageDto> SendMessage(int clientId, int vendorId, ChatMessageCreateDto messageDto);

        Task<IEnumerable<ChatMessageDto>> GetChatMessages(int clientId, int vendorId);

        Task<IEnumerable<NotificationDto>> GetClientNotifications(int clientId);

        Task<DisputeDto> RaiseDispute(int clientId, int vendorId, int requestId, DisputeCreateDto disputeDto);

        Task<IEnumerable<DisputeDto>> GetClientDisputes(int clientId);
        Task<List<ServiceDto>> GetNearbyServices(double userLat, double userLon);
    }
}