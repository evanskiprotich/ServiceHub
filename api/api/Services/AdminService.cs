using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class AdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Task<User> RegisterAdmin(User admin)
        {
            return _adminRepository.CreateAdmin(admin);
        }

        //public Task<User> LoginAdmin(string email, string password)
        //{
        //    return _adminRepository.AuthenticateAdmin(email, password);
        //}

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return _adminRepository.GetAllUsers();
        }

        public Task<bool> DeleteUser(int userId)
        {
            return _adminRepository.DeleteUser(userId);
        }

        public Task<IEnumerable<Service>> GetAllServices()
        {
            return _adminRepository.GetAllServices();
        }

        public Task<bool> DeleteService(int serviceId)
        {
            return _adminRepository.DeleteService(serviceId);
        }

        public Task<IEnumerable<ServiceRequest>> GetAllServiceRequests()
        {
            return _adminRepository.GetAllServiceRequests();
        }

        public Task<IEnumerable<Payment>> GetAllPayments()
        {
            return _adminRepository.GetAllPayments();
        }
    }
}
