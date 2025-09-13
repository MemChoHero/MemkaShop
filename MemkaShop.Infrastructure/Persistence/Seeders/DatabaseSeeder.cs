using MemkaShop.Domain.InfrastructureInterfaces.Persistence;
using MemkaShop.Infrastructure.Persistence.Factories;

namespace MemkaShop.Infrastructure.Persistence.Seeders;

public class DatabaseSeeder(AppDbContext appDbContext) : IDatabaseSeeder
{
    public async Task RunAsync()
    {
        await SeedBrandsAsync();
        await SeedBrandsAndCategoriesAsync();

        await appDbContext.SaveChangesAsync();
    }

    private async Task SeedBrandsAsync()
    {
        var brands = BrandFactory.GenerateMany(20);
        await appDbContext.AddRangeAsync(brands);
    }

    private async Task SeedBrandsAndCategoriesAsync()
    {
        var categories = CategoryFactory.GenerateMany(5);
        var products = ProductFactory.GenerateMany(100);

        await using var transaction = await appDbContext.Database.BeginTransactionAsync();

        await appDbContext.AddRangeAsync(categories);
        await appDbContext.SaveChangesAsync();

        foreach (var product in products)
        {
            var category = categories.ToList()[new Random().Next(0, categories.Count)];

            product.Categories.Add(category);
        }

        await appDbContext.AddRangeAsync(products);
        await appDbContext.SaveChangesAsync();

        await transaction.CommitAsync();
    }
}

