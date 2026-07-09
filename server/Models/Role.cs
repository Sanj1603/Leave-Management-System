using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}