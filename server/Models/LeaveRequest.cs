using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveId { get; set; }

        public int EmployeeId { get; set; }

        public int LeaveTypeId { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        public decimal Days { get; set; }

        [MaxLength(500)]
        public string Reason { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        public int? ApprovedBy { get; set; }

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DecisionAt { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public User Employee { get; set; } = null!;

        [ForeignKey(nameof(LeaveTypeId))]
        public LeaveType LeaveType { get; set; } = null!;

        [ForeignKey(nameof(ApprovedBy))]
        public User? Approver { get; set; }
    }
}