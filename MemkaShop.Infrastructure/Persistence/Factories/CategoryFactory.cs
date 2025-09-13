using Bogus;
using MemkaShop.Infrastructure.Persistence.Models;

namespace MemkaShop.Infrastructure.Persistence.Factories;

public static class CategoryFactory
{
    private static readonly Faker<Category> Faker = new Faker<Category>()
        .CustomInstantiator(f => new Category
        {
            Name = f.Commerce.Categories(1)[0]
        });

    public static Category GenerateOne()
    {
        return Faker.Generate();
    }

    public static List<Category> GenerateMany(int count)
    {
        return Faker.Generate(count);
    }
}