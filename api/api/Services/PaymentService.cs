using api.Interfaces;
using DotNetEnv;
using Newtonsoft.Json;
using System.Text;

namespace api.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _mpesaConsumerKey;
        private readonly string _mpesaConsumerSecret;
        private readonly string _lipaNaMpesaShortcode;
        private readonly string _lipaNaMpesaPasskey;
        private readonly string _lipaNaMpesaPasssecret;
        private readonly string _lipaNaMpesaCallbackUrl;
        private readonly string _lipaNaMpesaAccountNumber;

        public PaymentService()
        {
            _httpClient = new HttpClient();
            Env.Load();

            _mpesaConsumerKey = Env.GetString("MPESA_CONSUMER_KEY");
            _mpesaConsumerSecret = Env.GetString("MPESA_CONSUMER_SECRET");
            _lipaNaMpesaShortcode = Env.GetString("MPESA_LIPA_NA_MPESA_SHORTCODE");
            _lipaNaMpesaPasskey = Env.GetString("MPESA_LIPA_NA_MPESA_SHORTCODE_PASSKEY");
            _lipaNaMpesaPasssecret = Env.GetString("MPESA_LIPA_NA_MPESA_SHORTCODE_PASSSECRET");
            _lipaNaMpesaCallbackUrl = Env.GetString("MPESA_LIPA_NA_MPESA_SHORTCODE_CALLBACK_URL");
            _lipaNaMpesaAccountNumber = Env.GetString("MPESA_LIPA_NA_MPESA_SHORTCODE_ACCOUNT_NUMBER");
        }

        public async Task<string> InitiatePaymentAsync(decimal amount, string phoneNumber)
        {
            var token = await GetMpesaTokenAsync();
            var url = "https://sandbox.safaricom.co.ke/mpesa/stkpush/v1/processrequest";
            var request = new
            {
                BusinessShortCode = _lipaNaMpesaShortcode,
                Password = GeneratePassword(),
                Timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"),
                TransactionType = "CustomerPayBillOnline",
                Amount = amount,
                PartyA = phoneNumber,
                PartyB = _lipaNaMpesaShortcode,
                PhoneNumber = phoneNumber,
                CallBackURL = _lipaNaMpesaCallbackUrl,
                AccountNumber = _lipaNaMpesaAccountNumber,
                // Optional parameters
                // Description = "Payment for service",
                // Remark = "Payment"
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await _httpClient.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> GetMpesaTokenAsync()
        {
            var url = "https://sandbox.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials";
            var auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_mpesaConsumerKey}:{_mpesaConsumerSecret}"));

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");

            var response = await _httpClient.GetAsync(url);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(jsonResponse);

            return data.access_token;
        }

        private string GeneratePassword()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var password = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_lipaNaMpesaShortcode}{_lipaNaMpesaPasskey}{timestamp}"));
            return password;
        }
    }
}
