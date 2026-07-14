using server.DTOs;
using server.DTOs.User;

namespace server.Services.Interfaces
{
    public interface IUserService
    {
        // Users
        Task<IEnumerable<UserDto>> GetAllAsync();

        Task<UserDto?> GetByIdAsync(int id);

        // Dropdown APIs
        Task<IEnumerable<ManagerDto>> GetManagersAsync();

        Task<IEnumerable<ManagerDto>> GetAdminsAsync();

        // CRUD
        Task<UserDto> CreateAsync(CreateUserDto dto);

        Task<UserDto> UpdateAsync(int id, UpdateUserDto dto);

        Task DeleteAsync(int id);

        // Soft Delete
        Task DeactivateAsync(int id);

        // Employee/Manager Profile Update
        Task UpdateProfileAsync(int id, UpdateProfileDto dto);
    }
}