namespace api.Dtos.Payment
{
    public class PaymentCreateDto
    {
        public int RequestID { get; set; }
        public int ClientID { get; set; }
        public int VendorID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // SendMoney, LipaNaMpesa
        public string TransactionID { get; set; }
        public string Status { get; set; }
    }
}
