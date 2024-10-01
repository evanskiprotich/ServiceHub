namespace api.Dtos.Dispute;

public class DisputeCreateDto
{
    public int RequestID { get; set; }
    public int ClientID { get; set; }
    public int VendorID { get; set; }
    public string Issue { get; set; }
    public string Status { get; set; } = "Pending";
    public string Resolution { get; set; }
}