using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int EmployeeId { get; set; }

        public DateOnly AttendanceDate { get; set; }

        public TimeOnly? CheckIn { get; set; }

        public TimeOnly? CheckOut { get; set; }

        public decimal? WorkingHours { get; set; }

        public decimal? OTHours { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Present";

        [MaxLength(255)]
        public string? Remarks { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public User Employee { get; set; } = null!;
    }
}