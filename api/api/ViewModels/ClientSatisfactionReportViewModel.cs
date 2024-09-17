namespace api.ViewModels
{
    public class ClientSatisfactionReportViewModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int TotalReviewsGiven { get; set; }
        public double AverageRatingGiven { get; set; }
        public int TotalRequestsMade { get; set; }
        public int TotalCancelledRequests { get; set; }
    }
}
