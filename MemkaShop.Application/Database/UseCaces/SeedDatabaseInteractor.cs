using MemkaShop.Domain.Services.Interfaces;

namespace MemkaShop.Application.Database.UseCaces;

public class SeedDatabaseInteractor(ISeedDatabaseService service) 
{
    public async Task InvokeAsync()
    {
        await service.Seed();
    }
}
