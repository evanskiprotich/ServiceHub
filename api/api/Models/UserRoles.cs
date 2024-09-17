using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class UserRoles
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; } 
        public int RoleId { get; set; } 

        // Navigation properties
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
