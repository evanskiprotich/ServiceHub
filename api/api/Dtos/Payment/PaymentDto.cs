namespace api.Dtos.Payment
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int RequestID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionID { get; set; }
        public string Status { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public DateTime PaidAt { get; set; } // Date and time of payment
    }
}
