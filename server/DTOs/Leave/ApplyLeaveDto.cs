using System.ComponentModel.DataAnnotations;

namespace server.DTOs.Leave
{
    public class ApplyLeaveRequestDto
    {
        [Required]
        public int LeaveTypeId { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public string LeaveDuration { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Reason { get; set; } = string.Empty;
    }
}