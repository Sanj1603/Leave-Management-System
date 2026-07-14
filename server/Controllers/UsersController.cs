using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.DTOs.User;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // ==========================================
        // Get All Users
        // ==========================================
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // ==========================================
        // Get User By Id
        // ==========================================
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }

        // ==========================================
        // Get Admins
        // ==========================================
        [HttpGet("admins")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetAdmins()
        {
            var admins = await _userService.GetAdminsAsync();
            return Ok(admins);
        }

        // ==========================================
        // Get Managers
        // ==========================================
        [HttpGet("managers")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetManagers()
        {
            var managers = await _userService.GetManagersAsync();
            return Ok(managers);
        }

        // ==========================================
        // Create User
        // ==========================================
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = user.UserId },
                user);
        }

        // ==========================================
        // Update User (Admin)
        // ==========================================
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.UpdateAsync(id, dto);

            return Ok(user);
        }

        // ==========================================
        // Update Own Profile
        // ==========================================
        [HttpPut("{id}/profile")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] UpdateProfileDto dto)
        {
            await _userService.UpdateProfileAsync(id, dto);

            return Ok(new
            {
                Message = "Profile updated successfully."
            });
        }

        // ==========================================
        // Deactivate User
        // ==========================================
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _userService.DeactivateAsync(id);

            return Ok(new
            {
                Message = "User deactivated successfully."
            });
        }
    }
}