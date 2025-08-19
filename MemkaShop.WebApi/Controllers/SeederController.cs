using MemkaShop.Application.Database.UseCaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemkaShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeederController : ControllerBase
    {
        private readonly SeedDatabaseInteractor _interactor;
        private readonly ILogger<SeederController> _logger;

        public SeederController(SeedDatabaseInteractor interactor, ILogger<SeederController> logger)
        {
            _interactor = interactor;
            _logger = logger;
        }

        [HttpPost(Name = "seed")]
        public async Task<IActionResult> Seed()
        {
            await _interactor.Invoke();

            _logger.LogInformation("Seeding successfully");

            return Ok(new { Message = "Seeding successfully" });
        }
    }
}
