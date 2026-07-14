using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===================== GET ALL =====================

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .Where(u => u.IsActive)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        // ===================== EMAIL =====================

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await GetByEmailAsync(email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<bool> EmailExistsAsync(string email, int excludeUserId)
        {
            return await _context.Users
                .AnyAsync(u =>
                    u.Email == email &&
                    u.UserId != excludeUserId);
        }

        // ===================== ROLE FILTERS =====================

        public async Task<IEnumerable<User>> GetAdminsAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Where(u => u.RoleId == 1 && u.IsActive)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetManagersAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Where(u => u.RoleId == 2 && u.IsActive)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetEmployeesAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Where(u => u.RoleId == 3 && u.IsActive)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByManagerIdAsync(int managerId)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .Where(u => u.ManagerId == managerId && u.IsActive)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        // ===================== CREATE =====================

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // ===================== UPDATE =====================

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // ===================== DELETE =====================

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateAsync(User user)
        {
            user.IsActive = false;

            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }

        // ===================== SAVE =====================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // ===================== EXISTS =====================

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Users
                .AnyAsync(u => u.UserId == id);
        }
    }
}