namespace api.Models
{
    public class ChatMessage
    {
        public int MessageID { get; set; }
        public int RequestID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string MessageText { get; set; }
        public DateTime SentAt { get; set; }

        // Navigation Properties
        public ServiceRequest ServiceRequest { get; set; } 
        public User Sender { get; set; } 
        public User Receiver { get; set; }  
    }
}
