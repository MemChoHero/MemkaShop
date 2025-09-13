using MemkaShop.Domain.InfrastructureInterfaces.Persistence;
using MemkaShop.Domain.Services.Interfaces;

namespace MemkaShop.Domain.Services;

public class SeedDatabaseService(IDatabaseSeeder seeder)  : ISeedDatabaseService
{
    public async Task Seed()
    {
        await seeder.RunAsync();
    }
}
