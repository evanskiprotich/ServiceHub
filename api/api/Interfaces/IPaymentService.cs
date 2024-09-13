namespace api.Interfaces
{
    public interface IPaymentService
    {
        Task<string> InitiatePaymentAsync(decimal amount, string phoneNumber);
    }
}
