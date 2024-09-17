namespace api.ViewModels
{
    public class VendorPerformanceReportViewModel
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public int TotalServices { get; set; }
        public decimal TotalEarnings { get; set; }
        public int TotalReviews { get; set; }
        public double AverageRating { get; set; }
    }
}
