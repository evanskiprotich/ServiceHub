namespace api.Dtos.Service
{
    public class ServiceCreateDto
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Cost { get; set; }
        public string IsAvailable { get; set; }
    }

    public class ServiceUpdateDto
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Cost { get; set; }
        public string IsAvailable { get; set; }
    }
}
