using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Dispute
    {
        [Key]
        public int DisputeID { get; set; } 
        public int RequestID { get; set; }  
        public int ClientID { get; set; }   
        public int VendorID { get; set; }   
        public string Issue { get; set; }   
        public string Status { get; set; }  // Pending, Resolved
        public string Resolution { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.Now;  
        public DateTime? ResolvedAt { get; set; }  

        // Navigation properties
        public ServiceRequest ServiceRequest { get; set; }
        public User Client { get; set; }
        public User Vendor { get; set; }
    }
}
