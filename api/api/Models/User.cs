namespace api.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } // Admin, Vendor, Client
        public string Location { get; set; }
        public double? Latitude { get; set; } 
        public double? Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        // Navigation Properties
        public ICollection<Service> Services { get; set; }  // Vendor's Services
        public ICollection<ServiceRequest> ClientServiceRequests { get; set; } // Client's Requests
        public ICollection<ServiceRequest> VendorServiceRequests { get; set; } // Vendor's Received Requests
        public ICollection<Payment> ClientPayments { get; set; } // Payments made by Client
        public ICollection<Payment> VendorPayments { get; set; } // Payments received by Vendor
        public ICollection<Review> Reviews { get; set; } // Reviews by Client
        public ICollection<ChatMessage> SentMessages { get; set; } // Sent Messages
        public ICollection<ChatMessage> ReceivedMessages { get; set; } // Received Messages
    }
}
