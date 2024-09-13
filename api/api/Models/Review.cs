namespace api.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public int Rating { get; set; } // 1-5 stars
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        // Navigation Properties
        public User Client { get; set; } 
        public Service Service { get; set; } 
    }
}
