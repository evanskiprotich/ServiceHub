using api.Dtos.Service;
using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class VendorService
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        //public Task<User> RegisterVendor(User vendor)
        //{
        //    return _vendorRepository.CreateVendor(vendor);
        //}

        //public Task<User> LoginVendor(string email, string password)
        //{
        //    return _vendorRepository.AuthenticateVendor(email, password);
        //}

        public Task<IEnumerable<Service>> GetVendorServices(int vendorId)
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

        public Task<IEnumerable<ServiceRequest>> GetServiceRequests(int vendorId)
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

        public Task<Payment> GetPaymentDetails(int vendorId, int requestId)
        {
            return _vendorRepository.GetPaymentDetails(vendorId, requestId);
        }

        public Task<IEnumerable<Payment>> GetVendorPayments(int vendorId)
        {
            return _vendorRepository.GetVendorPayments(vendorId);
        }

        public Task<ChatMessage> SendMessage(int vendorId, int clientId, ChatMessage message)
        {
            return _vendorRepository.SendMessage(vendorId, clientId, message);
        }

        public Task<IEnumerable<ChatMessage>> GetChatMessages(int vendorId, int clientId)
        {
            return _vendorRepository.GetChatMessages(vendorId, clientId);
        }

        public Task<User> UpdateVendorProfile(int vendorId, User vendor)
        {
            return _vendorRepository.UpdateVendorProfile(vendorId, vendor);
        }

        public Task<IEnumerable<Notification>> GetVendorNotifications(int vendorId)
        {
            return _vendorRepository.GetVendorNotifications(vendorId);
        }
    }
}
