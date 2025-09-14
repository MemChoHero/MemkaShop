using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemkaShop.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TestController : Controller
{
    [HttpGet("/me")]
    public IActionResult GetMe()
    {
        return Ok(new { Email = User.FindFirst(ClaimTypes.Email)?.Value });
    }
}