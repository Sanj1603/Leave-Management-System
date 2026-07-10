using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LeaveController : ControllerBase
{
    [HttpGet]
    public IActionResult GetLeaves()
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult ApplyLeave()
    {
        return Ok();
    }

    [Authorize(Roles = "Admin")]
[HttpGet("report")]
public IActionResult LeaveReport()
{
    return Ok();
}

[Authorize(Roles = "Manager")]
[HttpPut("{id}/approve")]
public IActionResult ApproveLeave(int id)
{
    return Ok();
}

[Authorize(Roles = "Manager")]
[HttpPut("{id}/reject")]
public IActionResult RejectLeave(int id)
{
    return Ok();
}
}