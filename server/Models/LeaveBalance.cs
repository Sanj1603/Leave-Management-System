using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class LeaveBalance
    {
        [Key]
        public int BalanceId { get; set; }

        public int EmployeeId { get; set; }

        public int LeaveTypeId { get; set; }

        public int RemainingLeaves { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public User Employee { get; set; } = null!;

        [ForeignKey(nameof(LeaveTypeId))]
        public LeaveType LeaveType { get; set; } = null!;
    }
}