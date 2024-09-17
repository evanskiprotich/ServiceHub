using api.Data;
using api.Interfaces;
using api.Models;
using api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _context;

        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        // Client-Related Reports
        public async Task<IEnumerable<ServiceRequest>> GetServiceRequestHistory(int clientId)
        {
            return await _context.ServiceRequests
                .FromSqlRaw("EXEC GetServiceRequestHistory @ClientId = {0}", clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentReport(int clientId)
        {
            return await _context.Payments
                .FromSqlRaw("EXEC GetPaymentReport @ClientId = {0}", clientId)
                .ToListAsync();
        }

        public async Task<ClientActivityReportViewModel> GetClientActivityReport(int clientId)
        {
            return await _context.ClientActivityReports
                .FromSqlRaw("EXEC GetClientActivityReport @ClientId = {0}", clientId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewReport(int clientId)
        {
            return await _context.Reviews
                .FromSqlRaw("EXEC GetReviewReport @ClientId = {0}", clientId)
                .ToListAsync();
        }

        // Vendor-Related Reports
        public async Task<EarningsReportViewModel> GetEarningsReport(int vendorId)
        {
            return await _context.EarningsReports
                .FromSqlRaw("EXEC GetEarningsReport @VendorId = {0}", vendorId)
                .FirstOrDefaultAsync();
        }

        public async Task<ServicePerformanceReportViewModel> GetServicePerformanceReport(int vendorId)
        {
            return await _context.ServicePerformanceReports
                .FromSqlRaw("EXEC GetServicePerformanceReport @VendorId = {0}", vendorId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ServiceRequest>> GetServiceRequestReport(int vendorId)
        {
            return await _context.ServiceRequests
                .FromSqlRaw("EXEC GetServiceRequestReport @VendorId = {0}", vendorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetClientFeedbackReport(int vendorId)
        {
            return await _context.Reviews
                .FromSqlRaw("EXEC GetClientFeedbackReport @VendorId = {0}", vendorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<WithdrawalReportViewModel>> GetWithdrawalReport(int vendorId)
        {
            return await _context.WithdrawalReports
                .FromSqlRaw("EXEC GetWithdrawalReport @VendorId = {0}", vendorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ChatInteractionViewModel>> GetChatInteractionsReport(int vendorId)
        {
            return await _context.ChatInteractionViews
                .FromSqlRaw("EXEC GetChatInteractionsReport @VendorId = {0}", vendorId)
                .ToListAsync();
        }

        // Admin-Related Reports
        public async Task<IEnumerable<UserActivityReportViewModel>> GetUserActivityReport()
        {
            return await _context.UserActivityReports
                .FromSqlRaw("EXEC GetUserActivityReport")
                .ToListAsync();
        }

        public async Task<FinancialReportViewModel> GetFinancialReport()
        {
            return await _context.FinancialReports
                .FromSqlRaw("EXEC GetFinancialReport")
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DisputeResolutionReportViewModel>> GetDisputeResolutionReport()
        {
            return await _context.DisputeResolutionReports
                .FromSqlRaw("EXEC GetDisputeResolutionReport")
                .ToListAsync();
        }

        public async Task<ServicePopularityReportViewModel> GetServicePopularityReport()
        {
            return await _context.ServicePopularityReports
                .FromSqlRaw("EXEC GetServicePopularityReport")
                .FirstOrDefaultAsync();
        }

        public async Task<VendorPerformanceReportViewModel> GetVendorPerformanceReport()
        {
            return await _context.VendorPerformanceReports
                .FromSqlRaw("EXEC GetVendorPerformanceReport")
                .FirstOrDefaultAsync();
        }

        public async Task<PlatformGrowthReportViewModel> GetPlatformGrowthReport()
        {
            return await _context.PlatformGrowthReports
                .FromSqlRaw("EXEC GetPlatformGrowthReport")
                .FirstOrDefaultAsync();
        }

        public async Task<ClientSatisfactionReportViewModel> GetClientSatisfactionReport()
        {
            return await _context.ClientSatisfactionReports
                .FromSqlRaw("EXEC GetClientSatisfactionReport")
                .FirstOrDefaultAsync();
        }

        public async Task<RevenueReportViewModel> GetRevenueReport()
        {
            return await _context.RevenueReports
                .FromSqlRaw("EXEC GetRevenueReport")
                .FirstOrDefaultAsync();
        }
    }
}
