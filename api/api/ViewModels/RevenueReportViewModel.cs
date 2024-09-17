namespace api.ViewModels
{
    public class RevenueReportViewModel
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalFeesCollected { get; set; }
        public DateTime ReportGeneratedAt { get; set; }
    }
}
