using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.Repositories.Interfaces
{
    public interface ILeaveRepository
    {
        Task<LeaveRequest> ApplyLeaveAsync(LeaveRequest leaveRequest);
        Task<IEnumerable<LeaveRequest>> GetLeavesByUserIdAsync(int userId);
        Task<IEnumerable<LeaveRequest>> GetAllPendingLeavesAsync();
        Task<LeaveRequest?> GetLeaveByIdAsync(int leaveRequestId);
        Task UpdateLeaveAsync(LeaveRequest leaveRequest);
    }
}
