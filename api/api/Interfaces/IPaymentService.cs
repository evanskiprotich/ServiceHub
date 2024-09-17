namespace api.Interfaces
{
    public interface IPaymentService
    {
        Task<string> SendMoneyB2CAsync(decimal amount, string phoneNumber);
    }
}
