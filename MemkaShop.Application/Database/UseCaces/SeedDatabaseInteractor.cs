using MemkaShop.Domain.Services.Interfaces;

namespace MemkaShop.Application.Database.UseCaces
{
    public class SeedDatabaseInteractor
    {
        private readonly ISeedDatabaseService _service;

        public SeedDatabaseInteractor(ISeedDatabaseService service) 
        {
            _service = service;
        }

        public async Task Invoke()
        {
            await _service.Seed();
        }
    }
}
