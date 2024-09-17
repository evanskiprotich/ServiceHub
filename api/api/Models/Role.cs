using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } // Admin, Vendor, Client
    }
}
