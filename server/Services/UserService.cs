using AutoMapper;
using BCrypt.Net;
using server.DTOs;
using server.DTOs.User;
using server.Helpers;
using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        // ===========================
        // Get All Users
        // ===========================

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetActiveUsersAsync();

            return users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Address = u.Address,
                DateofJoining = u.DateofJoining,
                ProfilePictureUrl = u.ProfilePictureUrl,
                Designation = u.Designation,

                IsActive = u.IsActive,

                RoleId = u.RoleId,
                RoleName = u.Role?.RoleName ?? "",

                DepartmentId = u.DepartmentId,
                DepartmentName = u.Department?.DepartmentName ?? "",

                ManagerId = u.ManagerId,
                ManagerName = u.Manager?.Name
            });
        }

        // ===========================
        // Get User By Id
        // ===========================

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return null;

            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                DateofJoining = user.DateofJoining,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Designation = user.Designation,

                IsActive = user.IsActive,

                RoleId = user.RoleId,
                RoleName = user.Role?.RoleName ?? "",

                DepartmentId = user.DepartmentId,
                DepartmentName = user.Department?.DepartmentName ?? "",

                ManagerId = user.ManagerId,
                ManagerName = user.Manager?.Name
            };
        }

        // ===========================
        // Get Managers
        // ===========================

        public async Task<IEnumerable<ManagerDto>> GetManagersAsync()
        {
            var managers = await _userRepository.GetManagersAsync();

            return managers.Select(x => new ManagerDto
            {
                UserId = x.UserId,
                Name = x.Name
            });
        }

        // ===========================
        // Get Admins
        // ===========================

        public async Task<IEnumerable<ManagerDto>> GetAdminsAsync()
        {
            var admins = await _userRepository.GetAdminsAsync();

            return admins.Select(x => new ManagerDto
            {
                UserId = x.UserId,
                Name = x.Name
            });
        }
                // ===========================
        // Create User
        // ===========================

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            await ValidateEmailAsync(dto.Email);
            await ValidateRoleAsync(dto.RoleId);
            await ValidateDepartmentAsync(dto.DepartmentId);
            await ValidateHierarchyAsync(dto.RoleId, dto.ManagerId);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),

                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address ?? string.Empty,
                DateofJoining = dto.DateOfJoining.ToString("yyyy-MM-dd"),
                ProfilePictureUrl = dto.ProfilePictureUrl ?? string.Empty,
                Designation = dto.Designation,

                RoleId = dto.RoleId,
                DepartmentId = dto.DepartmentId,
                ManagerId = dto.ManagerId,

                IsActive = dto.IsActive
            };

            user = await _userRepository.CreateAsync(user);

            user = await _userRepository.GetByIdAsync(user.UserId)
                ?? throw new Exception("Failed to retrieve created user.");

            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                DateofJoining = user.DateofJoining,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Designation = user.Designation,
                IsActive = user.IsActive,

                RoleId = user.RoleId,
                RoleName = user.Role?.RoleName ?? "",

                DepartmentId = user.DepartmentId,
                DepartmentName = user.Department?.DepartmentName ?? "",

                ManagerId = user.ManagerId,
                ManagerName = user.Manager?.Name
            };
        }

        // ===========================
        // Update User (Admin)
        // ===========================

        public async Task<UserDto> UpdateAsync(int id, UpdateUserDto dto)
        {
            if (dto.ManagerId == id)
                throw new Exception("A user cannot be their own manager.");

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("User not found.");

            await ValidateRoleAsync(dto.RoleId);
            await ValidateDepartmentAsync(dto.DepartmentId);
            await ValidateHierarchyAsync(dto.RoleId, dto.ManagerId);

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.Address = dto.Address;
            user.DateofJoining = dto.DateofJoining;
            user.ProfilePictureUrl = dto.ProfilePictureUrl;
            user.Designation = dto.Designation;

            user.RoleId = dto.RoleId;
            user.DepartmentId = dto.DepartmentId;
            user.ManagerId = dto.ManagerId;
            user.IsActive = dto.IsActive;

            user = await _userRepository.UpdateAsync(user);

            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                DateofJoining = user.DateofJoining,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Designation = user.Designation,
                IsActive = user.IsActive,

                RoleId = user.RoleId,
                RoleName = user.Role?.RoleName ?? "",

                DepartmentId = user.DepartmentId,
                DepartmentName = user.Department?.DepartmentName ?? "",

                ManagerId = user.ManagerId,
                ManagerName = user.Manager?.Name
            };
        }

        // ===========================
        // Update Profile
        // ===========================

        public async Task UpdateProfileAsync(int id, UpdateProfileDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("User not found.");

            user.PhoneNumber = dto.PhoneNumber;
            user.Address = dto.Address;
            user.ProfilePictureUrl = dto.ProfilePictureUrl;

            await _userRepository.UpdateAsync(user);
        }

        // ===========================
        // Delete User
        // ===========================

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("User not found.");

            await _userRepository.DeleteAsync(user);
        }

        // ===========================
        // Deactivate User
        // ===========================

        public async Task DeactivateAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("User not found.");

            await _userRepository.DeactivateAsync(user);
        }
                // ===========================
        // Validation Methods
        // ===========================

        private async Task ValidateRoleAsync(int roleId)
        {
            if (!await _roleRepository.ExistsAsync(roleId))
                throw new Exception("Invalid role selected.");
        }

        private async Task ValidateDepartmentAsync(int departmentId)
        {
            if (!await _departmentRepository.ExistsAsync(departmentId))
                throw new Exception("Invalid department selected.");
        }

        private async Task ValidateEmailAsync(string email)
        {
            if (await _userRepository.EmailExistsAsync(email))
                throw new Exception("Email already exists.");
        }

        private async Task ValidateHierarchyAsync(int roleId, int? managerId)
        {
            switch (roleId)
            {
                case RoleConstants.Admin:

                    if (managerId != null)
                        throw new Exception("Admin cannot have a manager.");

                    break;

                case RoleConstants.Manager:

                    if (managerId == null)
                        throw new Exception("Manager must report to an Admin.");

                    var admin = await _userRepository.GetByIdAsync(managerId.Value);

                    if (admin == null || admin.RoleId != RoleConstants.Admin)
                        throw new Exception("Manager must report to an Admin.");

                    break;

                case RoleConstants.Employee:

                    if (managerId == null)
                        throw new Exception("Employee must report to a Manager.");

                    var manager = await _userRepository.GetByIdAsync(managerId.Value);

                    if (manager == null || manager.RoleId != RoleConstants.Manager)
                        throw new Exception("Employee must report to a Manager.");

                    break;

                default:
                    throw new Exception("Invalid role.");
            }
        }
    }
}
