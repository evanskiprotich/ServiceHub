namespace api.Dtos.Dispute;

public class DisputeDto
{
    public int DisputeID { get; set; }
    public int RequestID { get; set; }
    public int ClientID { get; set; }
    public string ClientName { get; set; }
    public int VendorID { get; set; }
    public string VendorName { get; set; }
    public string Issue { get; set; }
    public string Status { get; set; }
    public string Resolution { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
}