using server.DTOs;

namespace server.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> Login(LoginRequestDto request);
}