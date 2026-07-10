using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LeaveRequest> ApplyLeaveAsync(LeaveRequest leaveRequest)
        {
            await _context.LeaveRequests.AddAsync(leaveRequest);
            await _context.SaveChangesAsync();

            return leaveRequest;
        }

        public async Task<IEnumerable<LeaveRequest>> GetLeavesByUserIdAsync(int userId)
        {
            return await _context.LeaveRequests
                .Include(l => l.User)
                .Include(l => l.LeaveType)
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.LeaveRequestId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllPendingLeavesAsync()
        {
            return await _context.LeaveRequests
                .Include(l => l.User)
                .Include(l => l.LeaveType)
                .Where(l => l.Status == "Pending")
                .OrderByDescending(l => l.LeaveRequestId)
                .ToListAsync();
        }

        public async Task<LeaveRequest?> GetLeaveByIdAsync(int leaveRequestId)
        {
            return await _context.LeaveRequests
                .Include(l => l.User)
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(l => l.LeaveRequestId == leaveRequestId);
        }

        public async Task UpdateLeaveAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);

            await _context.SaveChangesAsync();
        }
    }
}