using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class HolidayController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHolidays()
    {
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult AddHoliday()
    {
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult DeleteHoliday(int id)
    {
        return Ok();
    }
}