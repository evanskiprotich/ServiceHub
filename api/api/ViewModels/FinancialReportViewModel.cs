namespace api.ViewModels
{
    public class FinancialReportViewModel
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalWithdrawals { get; set; }
        public decimal PlatformFees { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
