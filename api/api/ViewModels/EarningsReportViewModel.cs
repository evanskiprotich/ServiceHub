namespace api.ViewModels
{
    public class EarningsReportViewModel
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal PendingPayments { get; set; }
        public decimal CompletedPayments { get; set; }
        public DateTime ReportGeneratedAt { get; set; }
    }
}
