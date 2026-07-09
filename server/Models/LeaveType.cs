using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LeaveTypeName { get; set; } = string.Empty;

        [Required]
        public int AllocatedLeaves { get; set; }

        // Navigation Properties
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

        public ICollection<LeaveBalance> LeaveBalances { get; set; } = new List<LeaveBalance>();
    }
}