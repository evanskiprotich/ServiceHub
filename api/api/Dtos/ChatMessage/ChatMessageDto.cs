namespace api.Dtos.ChatMessage
{
    public class ChatMessageDto
    {
        public int MessageID { get; set; }
        public int RequestID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string MessageText { get; set; }
        public DateTime SentAt { get; set; }
    }
}
