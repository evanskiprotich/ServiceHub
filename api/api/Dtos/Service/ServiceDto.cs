using api.Dtos.Review;

namespace api.Dtos.Service
{
    public class ServiceDto
    {
        public int ServiceID { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }
        public string IsAvailable { get; set; }
        public List<ReviewDto> Reviews { get; set; }  // Nested Reviews
    }
}
