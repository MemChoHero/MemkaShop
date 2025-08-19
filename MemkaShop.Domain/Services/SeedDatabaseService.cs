using MemkaShop.Domain.InfrastructureInterfaces.Persistence;
using MemkaShop.Domain.Services.Interfaces;

namespace MemkaShop.Domain.Services
{
    public class SeedDatabaseService : ISeedDatabaseService
    {
        private readonly IDatabaseSeeder _seeder;

        public SeedDatabaseService(IDatabaseSeeder seeder) 
        {
            _seeder = seeder;
        }

        public async Task Seed()
        {
            await _seeder.RunAsync();
        }
    }
}
