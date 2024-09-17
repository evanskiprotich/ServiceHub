namespace api.ViewModels
{
    public class UserActivityReportViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } // Client, Vendor, Admin
        public DateTime LastLogin { get; set; }
        public int TotalRequests { get; set; } // For Clients or Vendors
        public int TotalServices { get; set; } // For Vendors
    }
}
