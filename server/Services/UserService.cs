using AutoMapper;
using BCrypt.Net;
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

        #region Private Validation Methods

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

        #endregi