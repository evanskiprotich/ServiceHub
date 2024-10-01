namespace api.Dtos.ChatMessage;

public class ChatMessageUpdateDto
{
    public int RequestID { get; set; }
    public int SenderID { get; set; }
    public int ReceiverID { get; set; }
    public string MessageText { get; set; }
}