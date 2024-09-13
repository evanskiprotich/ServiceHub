namespace api.Dtos.User
{
    public class UserUpdateDto
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
