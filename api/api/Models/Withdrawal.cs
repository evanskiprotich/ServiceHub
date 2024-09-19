namespace api.Models
{
    public class Withdrawal
    {
        public int WithdrawalID { get; set; }  
        public int VendorID { get; set; }      
        public decimal Amount { get; set; }   
        public string PaymentMethod { get; set; } 
        public DateTime WithdrawalDate { get; set; } = DateTime.Now; 
        public string Status { get; set; }    
        public string TransactionID { get; set; } 

        // Navigation property
        public User Vendor { get; set; }
    }
}
