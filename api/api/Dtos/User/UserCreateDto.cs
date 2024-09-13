namespace api.Dtos.User
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } // "Admin", "Vendor", "Client"
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
