using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int RequestID { get; set; }
        public int ClientID { get; set; }
        public int VendorID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // SendMoney, LipaNaMpesa
        public string TransactionID { get; set; }

        // Navigation Properties
        public ServiceRequest ServiceRequest { get; set; } 
        public User Client { get; set; }  
        public User Vendor { get; set; }  
    }
}
