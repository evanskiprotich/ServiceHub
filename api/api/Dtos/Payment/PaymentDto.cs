namespace api.Dtos.Payment
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int RequestID { get; set; }
        public int ClientID { get; set; }
        public int VendorID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // "SendMoney", "LipaNaMpesa"
        public string TransactionID { get; set; }
    }
}
