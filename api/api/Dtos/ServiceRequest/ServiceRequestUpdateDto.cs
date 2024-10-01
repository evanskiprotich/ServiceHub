namespace api.Dtos.ServiceRequest
{
    public class ServiceRequestUpdateDto
    {
        public string Status { get; set; } // Pending, Accepted, Completed, Cancelled
        public string PaymentStatus { get; set; } // Paid, Unpaid
    }
}
