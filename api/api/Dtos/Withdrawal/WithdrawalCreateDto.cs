namespace api.Dtos.Withdrawal;

public class WithdrawalCreateDto
{
    public int VendorID { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public string Status { get; set; }
    public string TransactionID { get; set; }
}

public class WithdrawalUpdateDto
{
    public string Status { get; set; }
}