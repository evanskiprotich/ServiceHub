namespace api.ViewModels
{
    public class ChatInteractionViewModel
    {
        public int ChatId { get; set; }
        public string ClientName { get; set; }
        public string VendorName { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastInteractionDate { get; set; }
    }
}
