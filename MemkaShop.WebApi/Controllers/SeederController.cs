using MemkaShop.Application.Database.UseCaces;
using Microsoft.AspNetCore.Mvc;

namespace MemkaShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeederController(
    SeedDatabaseInteractor interactor, 
    ILogger<SeederController> logger,
    IWebHostEnvironment env) : ControllerBase
{

    [HttpPost(Name = "seed")]
    public async Task<IActionResult> Seed()
    {
        if (env.IsProduction()) return NotFound();
        
        await interactor.Invoke();

        logger.LogInformation("Seeding successfully");

        return Ok(new { Message = "Seeding successfully" });
    }
}
