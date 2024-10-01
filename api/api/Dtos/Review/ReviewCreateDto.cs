namespace api.Dtos.Review
{
    public class ReviewCreateDto
    {
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public int Rating { get; set; } // 1-5 stars
        public string Comment { get; set; }
    }
}
