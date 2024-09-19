using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
