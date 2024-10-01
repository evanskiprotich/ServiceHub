namespace api.Dtos.User
{
    public class UserUpdateDto
    {
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
