using api.Dtos.ChatMessage;
using api.Dtos.Dispute;
using api.Dtos.Payment;

namespace api.Dtos.ServiceRequest
{
    public class ServiceRequestDto
    {
        public int RequestID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public decimal TotalCost { get; set; }
        public List<PaymentDto> Payments { get; set; }  // Nested Payments
        public List<ChatMessageDto> ChatMessages { get; set; }  // Nested ChatMessages
        public List<DisputeDto> Disputes { get; set; }  // Nested Disputes
    }
}
