namespace api.Dtos.Withdrawal;

public class WithdrawalDto
{
    public int WithdrawalID { get; set; }
    public int VendorID { get; set; }
    public string VendorName { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime WithdrawalDate { get; set; }
    public string Status { get; set; }
    public string TransactionID { get; set; }
}