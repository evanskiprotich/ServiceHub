namespace api.Dtos.Review
{
    public class ReviewDto
    {
        public int ReviewID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
