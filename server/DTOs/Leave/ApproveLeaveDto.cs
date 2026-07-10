using System.ComponentModel.DataAnnotations;

namespace server.DTOs.Leave
{
    public class ApproveLeaveDto
    {
        [Required]
        [RegularExpression("Approved|Rejected")]
        public string Status { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? ManagerRemarks { get; set; }
    }
}