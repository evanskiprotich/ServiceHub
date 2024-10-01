namespace api.Dtos.Notification;

public class NotificationCreateDto
{
    public int UserId { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; } = false;
}