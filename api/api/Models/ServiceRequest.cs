using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ServiceRequest
    {
        [Key]
        public int RequestID { get; set; }
        public int ClientID { get; set; }
        public int VendorID { get; set; }
        public int ServiceID { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } // Pending, Accepted, Completed, Cancelled
        public string PaymentStatus { get; set; } // Paid, Unpaid
        public decimal TotalCost { get; set; } 

        // Navigation Properties
        public User Client { get; set; }  
        public User Vendor { get; set; }  
        public Service Service { get; set; } 
        public ICollection<Payment> Payments { get; set; } 
        public ICollection<ChatMessage> ChatMessages { get; set; } 
        public ICollection<Dispute> Disputes { get; set; }
    }
}
