namespace api.ViewModels
{
    public class ServicePopularityReportViewModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int TotalRequests { get; set; }
        public int TotalCompleted { get; set; }
        public int TotalReviews { get; set; }
    }
}
