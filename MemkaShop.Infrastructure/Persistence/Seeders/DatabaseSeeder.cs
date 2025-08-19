using MemkaShop.Domain.InfrastructureInterfaces.Persistence;
using MemkaShop.Infrastructure.Persistence.Factories;

namespace MemkaShop.Infrastructure.Persistence.Seeders
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly AppDbContext _db;

        public DatabaseSeeder(AppDbContext appDbContext) 
        {
            _db = appDbContext;
        }

        public async Task RunAsync()
        {
            var brands = BrandFactory.GenerateMany();

            await _db.AddRangeAsync(brands);
            await _db.SaveChangesAsync();
        }
    }
}
