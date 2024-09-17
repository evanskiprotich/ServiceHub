namespace api.Dtos.User
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleID { get; set; } // RoleID comes from dropdown, e.g., 1 = Client, 2 = Vendor
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
