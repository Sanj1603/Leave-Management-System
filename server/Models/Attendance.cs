using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Attendance
    {
        
        [Key]
        public int AttendanceId { get; set; }

    public int UserId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public TimeOnly? CheckInTime { get; set; }

    public TimeOnly? CheckOutTime { get; set; }

    public double WorkingHours { get; set; }

    public double OvertimeHours { get; set; }

    public string Status { get; set; } = string.Empty;

    public string? Remarks { get; set; }

    public User User { get; set; } = null!;

    }
}