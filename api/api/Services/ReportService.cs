using api.Interfaces;
using api.Models;
using api.ViewModels;

namespace api.Services
{
    public class ReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        // Client-Related Reports
        public async Task<IEnumerable<ServiceRequest>> GetServiceRequestHistory(int clientId)
        {
            return await _reportRepository.GetServiceRequestHistory(clientId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentReport(int clientId)
        {
            return await _reportRepository.GetPaymentReport(clientId);
        }

        public async Task<ClientActivityReportViewModel> GetClientActivityReport(int clientId)
        {
            return await _reportRepository.GetClientActivityReport(clientId);
        }

        public async Task<IEnumerable<Review>> GetReviewReport(int clientId)
        {
            return await _reportRepository.GetReviewReport(clientId);
        }

        // Vendor-Related Reports
        public async Task<EarningsReportViewModel> GetEarningsReport(int vendorId)
        {
            return await _reportRepository.GetEarningsReport(vendorId);
        }

        public async Task<ServicePerformanceReportViewModel> GetServicePerformanceReport(int vendorId)
        {
            return await _reportRepository.GetServicePerformanceReport(vendorId);
        }

        public async Task<IEnumerable<ServiceRequest>> GetServiceRequestReport(int vendorId)
        {
            return await _reportRepository.GetServiceRequestReport(vendorId);
        }

        public async Task<IEnumerable<Review>> GetClientFeedbackReport(int vendorId)
        {
            return await _reportRepository.GetClientFeedbackReport(vendorId);
        }

        public async Task<IEnumerable<WithdrawalReportViewModel>> GetWithdrawalReport(int vendorId)
        {
            return await _reportRepository.GetWithdrawalReport(vendorId);
        }

        public async Task<IEnumerable<ChatInteractionViewModel>> GetChatInteractionsReport(int vendorId)
        {
            return await _reportRepository.GetChatInteractionsReport(vendorId);
        }

        // Admin-Related Reports
        public async Task<IEnumerable<UserActivityReportViewModel>> GetUserActivityReport()
        {
            return await _reportRepository.GetUserActivityReport();
        }

        public async Task<FinancialReportViewModel> GetFinancialReport()
        {
            return await _reportRepository.GetFinancialReport();
        }

        public async Task<IEnumerable<DisputeResolutionReportViewModel>> GetDisputeResolutionReport()
        {
            return await _reportRepository.GetDisputeResolutionReport();
        }

        public async Task<ServicePopularityReportViewModel> GetServicePopularityReport()
        {
            return await _reportRepository.GetServicePopularityReport();
        }

        public async Task<VendorPerformanceReportViewModel> GetVendorPerformanceReport()
        {
            return await _reportRepository.GetVendorPerformanceReport();
        }

        public async Task<PlatformGrowthReportViewModel> GetPlatformGrowthReport()
        {
            return await _reportRepository.GetPlatformGrowthReport();
        }

        public async Task<ClientSatisfactionReportViewModel> GetClientSatisfactionReport()
        {
            return await _reportRepository.GetClientSatisfactionReport();
        }

        public async Task<RevenueReportViewModel> GetRevenueReport()
        {
            return await _reportRepository.GetRevenueReport();
        }
    }
}
