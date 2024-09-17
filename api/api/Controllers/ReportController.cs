using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        // Client-Related Reports
        [HttpGet("client/{clientId}/service-requests")]
        public async Task<IActionResult> GetServiceRequestHistory(int clientId)
        {
            var report = await _reportService.GetServiceRequestHistory(clientId);
            return Ok(report);
        }

        [HttpGet("client/{clientId}/payments")]
        public async Task<IActionResult> GetPaymentReport(int clientId)
        {
            var report = await _reportService.GetPaymentReport(clientId);
            return Ok(report);
        }

        [HttpGet("client/{clientId}/activity")]
        public async Task<IActionResult> GetClientActivityReport(int clientId)
        {
            var report = await _reportService.GetClientActivityReport(clientId);
            return Ok(report);
        }

        [HttpGet("client/{clientId}/reviews")]
        public async Task<IActionResult> GetReviewReport(int clientId)
        {
            var report = await _reportService.GetReviewReport(clientId);
            return Ok(report);
        }

        // Vendor-Related Reports
        [HttpGet("vendor/{vendorId}/earnings")]
        public async Task<IActionResult> GetEarningsReport(int vendorId)
        {
            var report = await _reportService.GetEarningsReport(vendorId);
            return Ok(report);
        }

        [HttpGet("vendor/{vendorId}/service-performance")]
        public async Task<IActionResult> GetServicePerformanceReport(int vendorId)
        {
            var report = await _reportService.GetServicePerformanceReport(vendorId);
            return Ok(report);
        }

        [HttpGet("vendor/{vendorId}/service-requests")]
        public async Task<IActionResult> GetServiceRequestReport(int vendorId)
        {
            var report = await _reportService.GetServiceRequestReport(vendorId);
            return Ok(report);
        }

        [HttpGet("vendor/{vendorId}/client-feedback")]
        public async Task<IActionResult> GetClientFeedbackReport(int vendorId)
        {
            var report = await _reportService.GetClientFeedbackReport(vendorId);
            return Ok(report);
        }

        [HttpGet("vendor/{vendorId}/withdrawals")]
        public async Task<IActionResult> GetWithdrawalReport(int vendorId)
        {
            var report = await _reportService.GetWithdrawalReport(vendorId);
            return Ok(report);
        }

        [HttpGet("vendor/{vendorId}/chat-interactions")]
        public async Task<IActionResult> GetChatInteractionsReport(int vendorId)
        {
            var report = await _reportService.GetChatInteractionsReport(vendorId);
            return Ok(report);
        }

        // Admin-Related Reports
        [HttpGet("user-activity")]
        public async Task<IActionResult> GetUserActivityReport()
        {
            var report = await _reportService.GetUserActivityReport();
            return Ok(report);
        }

        [HttpGet("financial")]
        public async Task<IActionResult> GetFinancialReport()
        {
            var report = await _reportService.GetFinancialReport();
            return Ok(report);
        }

        [HttpGet("dispute-resolution")]
        public async Task<IActionResult> GetDisputeResolutionReport()
        {
            var report = await _reportService.GetDisputeResolutionReport();
            return Ok(report);
        }

        [HttpGet("service-popularity")]
        public async Task<IActionResult> GetServicePopularityReport()
        {
            var report = await _reportService.GetServicePopularityReport();
            return Ok(report);
        }

        [HttpGet("vendor-performance")]
        public async Task<IActionResult> GetVendorPerformanceReport()
        {
            var report = await _reportService.GetVendorPerformanceReport();
            return Ok(report);
        }

        [HttpGet("platform-growth")]
        public async Task<IActionResult> GetPlatformGrowthReport()
        {
            var report = await _reportService.GetPlatformGrowthReport();
            return Ok(report);
        }

        [HttpGet("client-satisfaction")]
        public async Task<IActionResult> GetClientSatisfactionReport()
        {
            var report = await _reportService.GetClientSatisfactionReport();
            return Ok(report);
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenueReport()
        {
            var report = await _reportService.GetRevenueReport();
            return Ok(report);
        }
    }
}
