namespace api.ViewModels
{
    public class ClientActivityReportViewModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int TotalRequests { get; set; }
        public int CompletedRequests { get; set; }
        public int CancelledRequests { get; set; }
        public decimal TotalAmountSpent { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}
