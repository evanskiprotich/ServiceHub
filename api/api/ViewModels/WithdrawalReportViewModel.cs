namespace api.ViewModels
{
    public class WithdrawalReportViewModel
    {
        public int WithdrawalId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public string Status { get; set; } // Pending, Completed
    }
}
