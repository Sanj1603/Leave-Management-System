using AutoMapper;
using server.DTOs;
using server.DTOs.Department;
using server.DTOs.Roles;
using server.DTOs.User;
using server.Models;

namespace server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ==========================
            // User -> UserDto
            // ==========================
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName,
                    opt => opt.MapFrom(src => src.Role != null ? src.Role.RoleName : string.Empty))
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : string.Empty))
                .ForMember(dest => dest.ManagerName,
                    opt => opt.MapFrom(src =>
                        src.Manager != null ? src.Manager.Name : null));

            // User -> ManagerDto
            CreateMap<User, ManagerDto>();

            // CreateUserDto -> User
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash,
                    opt => opt.Ignore());

            // UpdateUserDto -> User
            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.PasswordHash,
                    opt => opt.Ignore());

            // UpdateProfileDto -> User
            CreateMap<UpdateProfileDto, User>()
                .ForMember(dest => dest.PasswordHash,
                    opt => opt.Ignore())
                .ForAllOtherMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // ==========================
            // Role
            // ==========================
            CreateMap<Role, RoleDto>();

            // ==========================
            // Department
            // ==========================
            CreateMap<Department, DepartmentDto>();
        }
    }
}