namespace api.Dtos.ServiceRequest
{
    public class ServiceRequestCreateDto
    {
        public int ClientID { get; set; }
        public int VendorID { get; set; }
        public int ServiceID { get; set; }
        public string Status { get; set; } // "Pending", "Accepted", "Completed", "Cancelled"
        public string PaymentStatus { get; set; } // "Paid", "Unpaid"
    }
}
