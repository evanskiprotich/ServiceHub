namespace api.ViewModels
{
    public class ServicePerformanceReportViewModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int TotalRequests { get; set; }
        public int CompletedRequests { get; set; }
        public int CancelledRequests { get; set; }
        public decimal TotalEarnings { get; set; }
    }
}
