namespace api.Dtos.Service
{
    public class ServiceDto
    {
        public int ServiceID { get; set; }
        public int VendorID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
