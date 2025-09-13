using Bogus;
using MemkaShop.Infrastructure.Persistence.Models;

namespace MemkaShop.Infrastructure.Persistence.Factories;

public static class ProductFactory
{
    private static readonly Faker<Product> Faker = new Faker<Product>()
        .CustomInstantiator(f => new Product
        {
            Title = f.Commerce.ProductName(),
            Description = f.Lorem.Paragraph(),
            Price = double.Parse(f.Commerce.Price(1, 1000)),
            Thumbnail = f.Image.PicsumUrl(),
        });

    public static Product GenerateOne()
    {
        return Faker.Generate();
    }

    public static List<Product> GenerateMany(int count)
    {
        return Faker.Generate(count);
    }
}
