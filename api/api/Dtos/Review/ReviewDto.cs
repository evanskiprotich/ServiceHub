namespace api.Dtos.Review
{
    public class ReviewDto
    {
        public int ReviewID { get; set; }
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public int Rating { get; set; } // Between 1 and 5
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
