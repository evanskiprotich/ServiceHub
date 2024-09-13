namespace api.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public int VendorID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public User Vendor { get; set; } 
        public ICollection<ServiceRequest> ServiceRequests { get; set; } // List of Requests for this service
        public ICollection<Review> Reviews { get; set; } // List of Reviews
    }
}
