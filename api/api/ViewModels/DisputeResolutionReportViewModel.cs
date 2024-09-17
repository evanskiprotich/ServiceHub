namespace api.ViewModels
{
    public class DisputeResolutionReportViewModel
    {
        public int DisputeId { get; set; }
        public string ClientName { get; set; }
        public string VendorName { get; set; }
        public string Issue { get; set; }
        public string Resolution { get; set; }
        public DateTime ResolutionDate { get; set; }
    }
}
