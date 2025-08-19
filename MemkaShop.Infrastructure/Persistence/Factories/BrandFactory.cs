using Bogus;
using MemkaShop.Infrastructure.Persistence.Models;

namespace MemkaShop.Infrastructure.Persistence.Factories
{
    public static class BrandFactory
    {
        private static readonly Faker<Brand> _faker = new Faker<Brand>()
            .CustomInstantiator(f => new Brand
            {
               Title = f.Company.CompanyName(),
               Description = f.Lorem.Sentence(),
            });

        public static Brand GenerateOne()
        {
            return _faker.Generate();
        }

        public static IEnumerable<Brand> GenerateMany()
        {
            return _faker.Generate(20);
        }
    }
}
