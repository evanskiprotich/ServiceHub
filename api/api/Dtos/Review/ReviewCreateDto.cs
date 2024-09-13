namespace api.Dtos.Review
{
    public class ReviewCreateDto
    {
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public int Rating { get; set; } // Between 1 and 5
        public string Comment { get; set; }
    }
}
