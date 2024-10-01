using api.Dtos.Service;
using api.Dtos.Payment;
using api.Dtos.Notification;
using api.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos.ChatMessage;
using api.Dtos.ServiceRequest;
using api.Dtos.User;

namespace api.Services
{
    public class VendorService
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        // public Task<UserDto> RegisterVendor(UserDto vendorDto)
        // {
        //     return _vendorRepository.CreateVendor(vendorDto);
        // }

        // public Task<UserDto> LoginVendor(string email, string password)
        // {
        //     return _vendorRepository.AuthenticateVendor(email, password);
        // }

        public Task<IEnumerable<ServiceDto>> GetVendorServices(int vendorId)
        {
            return _vendorRepository.GetVendorServices(vendorId);
        }

        public Task<ServiceCreateDto> AddService(int vendorId, ServiceCreateDto serviceDto)
        {
            return _vendorRepository.AddService(vendorId, serviceDto);
        }

        public Task<ServiceUpdateDto> UpdateService(int vendorId, int serviceId, ServiceUpdateDto serviceDto)
        {
            return _vendorRepository.UpdateService(vendorId, serviceId, serviceDto);
        }

        public Task<bool> RemoveService(int vendorId, int serviceId)
        {
            return _vendorRepository.RemoveService(vendorId, serviceId);
        }

        public Task<IEnumerable<ServiceRequestDto>> GetServiceRequests(int vendorId)
        {
            return _vendorRepository.GetServiceRequests(vendorId);
        }

        public Task<bool> AcceptServiceRequest(int vendorId, int requestId)
        {
            return _vendorRepository.AcceptServiceRequest(vendorId, requestId);
        }

        public Task<bool> RejectServiceRequest(int vendorId, int requestId)
        {
            return _vendorRepository.RejectServiceRequest(vendorId, requestId);
        }

        public Task<PaymentDto> GetPaymentDetails(int vendorId, int requestId)
        {
            return _vendorRepository.GetPaymentDetails(vendorId, requestId);
        }

        public Task<IEnumerable<PaymentDto>> GetVendorPayments(int vendorId)
        {
            return _vendorRepository.GetVendorPayments(vendorId);
        }

        public Task<ChatMessageDto> SendMessage(int vendorId, int clientId, ChatMessageDto messageDto)
        {
            return _vendorRepository.SendMessage(vendorId, clientId, messageDto);
        }

        public Task<IEnumerable<ChatMessageDto>> GetChatMessages(int vendorId, int clientId)
        {
            return _vendorRepository.GetChatMessages(vendorId, clientId);
        }

        public Task<UserDto> UpdateVendorProfile(int vendorId, UserDto vendorDto)
        {
            return _vendorRepository.UpdateVendorProfile(vendorId, vendorDto);
        }

        public Task<IEnumerable<NotificationDto>> GetVendorNotifications(int vendorId)
        {
            return _vendorRepository.GetVendorNotifications(vendorId);
        }
    }
}
