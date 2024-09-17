namespace api.ViewModels
{
    public class PlatformGrowthReportViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalVendors { get; set; }
        public int TotalServicesOffered { get; set; }
        public decimal TotalRevenueGenerated { get; set; }
        public DateTime ReportGeneratedAt { get; set; }
    }
}
