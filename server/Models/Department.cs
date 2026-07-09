using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}