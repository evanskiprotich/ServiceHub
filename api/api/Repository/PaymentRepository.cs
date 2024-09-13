using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext _context;

        public PaymentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByClientIdAsync(int clientId)
        {
            return await _context.Payments.Where(p => p.ClientID == clientId).ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByVendorIdAsync(int vendorId)
        {
            return await _context.Payments.Where(p => p.VendorID == vendorId).ToListAsync();
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await GetPaymentByIdAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
