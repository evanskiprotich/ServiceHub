using api.Models;

namespace api.Interfaces
{
    public interface IAdminRepository
    {
        Task<User> CreateAdmin(User admin);
        //Task<User> AuthenticateAdmin(string email, string password);

        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> DeleteUser(int userId);

        Task<IEnumerable<Service>> GetAllServices();
        Task<bool> DeleteService(int serviceId);

        Task<IEnumerable<ServiceRequest>> GetAllServiceRequests();
        Task<IEnumerable<Payment>> GetAllPayments();
    }
}
