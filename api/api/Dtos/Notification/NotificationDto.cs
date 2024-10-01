namespace api.Dtos.Notification;

public class NotificationDto
{
    public int NotificationID { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime SentAt { get; set; }
}