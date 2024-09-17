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
        private readonly string _b2cShortcode;
        private readonly string _initiatorName;
        private readonly string _b2cPasssecret;
        private readonly string _b2cCallbackUrl;

        public PaymentService()
        {
            _httpClient = new HttpClient();
            Env.Load();

            _mpesaConsumerKey = Env.GetString("MPESA_CONSUMER_KEY");
            _mpesaConsumerSecret = Env.GetString("MPESA_CONSUMER_SECRET");
            _b2cShortcode = Env.GetString("MPESA_B2C_SHORTCODE");
            _initiatorName = Env.GetString("MPESA_INITIATOR_NAME");
            _b2cPasssecret = Env.GetString("MPESA_B2C_PASSSECRET");
            _b2cCallbackUrl = Env.GetString("MPESA_B2C_CALLBACK_URL");
        }

        public async Task<string> SendMoneyB2CAsync(decimal amount, string phoneNumber)
        {
            var token = await GetMpesaTokenAsync();
            var url = "https://sandbox.safaricom.co.ke/mpesa/b2c/v1/paymentrequest";
            var request = new
            {
                InitiatorName = _initiatorName,
                SecurityCredential = _b2cPasssecret,
                CommandID = "BusinessPayment",  // Use "SalaryPayment" or "PromotionPayment" as needed
                Amount = amount,
                PartyA = _b2cShortcode,  // Shortcode sending money
                PartyB = phoneNumber,  // Phone number receiving money
                Remarks = "Payment for service",  // Any remark
                QueueTimeOutURL = _b2cCallbackUrl,  // Timeout callback
                ResultURL = _b2cCallbackUrl,  // Success callback
                Occasion = "Payment"  // Optional field
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
    }
}
