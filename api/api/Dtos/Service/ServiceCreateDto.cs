namespace api.Dtos.Service
{
    public class ServiceCreateDto
    {
        public int VendorID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Cost { get; set; }
    }
}
