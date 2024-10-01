namespace api.Dtos.Service
{
    public class ServiceCreateDto
    {
        public int ServiceID { get; set; } // If you want to keep track of ID on creation
        public string ServiceName { get; set; } = string.Empty;
        public string ServiceDescription { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public string IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; } // Date the service was created
    }

    public class ServiceUpdateDto
    {
        public int ServiceID { get; set; } // Unique identifier for the service
        public string ServiceName { get; set; } = string.Empty;
        public string ServiceDescription { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public string IsAvailable { get; set; }
        public DateTime UpdatedAt { get; set; } // Date the service was last updated
    }
}