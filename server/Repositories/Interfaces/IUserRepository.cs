using server.Models;

namespace server.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);

    Task<User?> GetUserByIdAsync(int userId);

    Task AddUserAsync(User user);

    Task SaveChangesAsync();
}