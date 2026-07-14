```csharp
using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // Get Users
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetActiveUsersAsync();
        Task<User?> GetByIdAsync(int id);

        // Email
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> EmailExistsAsync(string email, int excludeUserId);

        // Role-based Users
        Task<IEnumerable<User>> GetAdminsAsync();
        Task<IEnumerable<User>> GetManagersAsync();
        Task<IEnumerable<User>> GetEmployeesAsync();
        Task<IEnumerable<User>> GetByManagerIdAsync(int managerId);

        // CRUD
        Task AddAsync(User user);
        Task<User> CreateAsync(User user);

        Task UpdateAsync(User user);
        Task<User> UpdateAsync(User user);

        Task DeleteAsync(User user);
        Task DeactivateAsync(User user);

        Task SaveChangesAsync();

        // Validation
        Task<bool> ExistsAsync(int id);
    }
}

