using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        // Foreign key for Role
        public int RoleID { get; set; }
        public Role Role { get; set; } // Navigation property

        // Other navigation properties
        public ICollection<Service> Services { get; set; }
        public ICollection<ServiceRequest> ClientServiceRequests { get; set; }
        public ICollection<ServiceRequest> VendorServiceRequests { get; set; }
        public ICollection<Payment> ClientPayments { get; set; }
        public ICollection<Payment> VendorPayments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ChatMessage> SentMessages { get; set; }
        public ICollection<ChatMessage> ReceivedMessages { get; set; }
    }
}
