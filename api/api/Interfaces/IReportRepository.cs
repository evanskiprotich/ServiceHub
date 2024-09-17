using api.Models;
using api.ViewModels;

namespace api.Interfaces
{
    public interface IReportRepository
    {
        // Client-Related Reports
        Task<IEnumerable<ServiceRequest>> GetServiceRequestHistory(int clientId);
        Task<IEnumerable<Payment>> GetPaymentReport(int clientId);
        Task<ClientActivityReportViewModel> GetClientActivityReport(int clientId);
        Task<IEnumerable<Review>> GetReviewReport(int clientId);

        // Vendor-Related Reports
        Task<EarningsReportViewModel> GetEarningsReport(int vendorId);
        Task<ServicePerformanceReportViewModel> GetServicePerformanceReport(int vendorId);
        Task<IEnumerable<ServiceRequest>> GetServiceRequestReport(int vendorId);
        Task<IEnumerable<Review>> GetClientFeedbackReport(int vendorId);
        Task<IEnumerable<WithdrawalReportViewModel>> GetWithdrawalReport(int vendorId);
        Task<IEnumerable<ChatInteractionViewModel>> GetChatInteractionsReport(int vendorId);

        // Admin-Related Reports
        Task<IEnumerable<UserActivityReportViewModel>> GetUserActivityReport();
        Task<FinancialReportViewModel> GetFinancialReport();
        Task<IEnumerable<DisputeResolutionReportViewModel>> GetDisputeResolutionReport();
        Task<ServicePopularityReportViewModel> GetServicePopularityReport();
        Task<VendorPerformanceReportViewModel> GetVendorPerformanceReport();
        Task<PlatformGrowthReportViewModel> GetPlatformGrowthReport();
        Task<ClientSatisfactionReportViewModel> GetClientSatisfactionReport();
        Task<RevenueReportViewModel> GetRevenueReport();
    }
}
