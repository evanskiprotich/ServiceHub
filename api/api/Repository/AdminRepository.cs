using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAdmin(User admin)
        {
            _context.Users.Add(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        //public async Task<User> AuthenticateAdmin(string email, string password)
        //{
        //    return await _context.Users
        //        .FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.Role == "Admin");
        //}

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users
                .Where(u => u.RoleID == 2 || u.RoleID == 3)
                .ToListAsync();
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<bool> DeleteService(int serviceId)
        {
            var service = await _context.Services.FindAsync(serviceId);
            if (service == null) return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllServiceRequests()
        {
            return await _context.ServiceRequests.ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _context.Payments.ToListAsync();
        }

    }
}
