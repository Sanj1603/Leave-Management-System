using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult AddUser()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id)
    {
        return Ok();
    }

    [HttpPut("{id}/deactivate")]
    public IActionResult DeactivateUser(int id)
    {
        return Ok();
    }
}