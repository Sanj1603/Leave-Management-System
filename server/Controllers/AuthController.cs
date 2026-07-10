using Microsoft.AspNetCore.Mvc;
using server.DTOs.Auth;
using server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace server.Controllers;



[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        try
        {
            var response = await _authService.LoginAsync(request);

            if (response == null)
                return Unauthorized(new
                {
                    message = "Invalid email or password."
                });

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }
}