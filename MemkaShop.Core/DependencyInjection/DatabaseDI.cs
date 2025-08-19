using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MemkaShop.Infrastructure.Persistence;
using MemkaShop.Domain.InfrastructureInterfaces.Persistence;
using MemkaShop.Infrastructure.Persistence.Seeders;

namespace MemkaShop.Core.DependencyInjection
{
    public static class DatabaseDI
    {
        public static IServiceCollection AddDatabaseServices(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddTransient<IDatabaseSeeder, DatabaseSeeder>();

            return services;
        }
    }
}
