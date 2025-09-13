using Bogus;
using MemkaShop.Infrastructure.Persistence.Models;

namespace MemkaShop.Infrastructure.Persistence.Factories;

public static class BrandFactory
{
    private static readonly Faker<Brand> Faker = new Faker<Brand>()
        .CustomInstantiator(f => new Brand
        {
           Title = f.Company.CompanyName(),
           Description = f.Lorem.Sentence(),
        });

    public static Brand GenerateOne()
    {
        return Faker.Generate();
    }

    public static IEnumerable<Brand> GenerateMany(int count)
    {
        return Faker.Generate(count);
    }
}
