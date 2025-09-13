using MemkaShop.Domain.Services;
using MemkaShop.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MemkaShop.Core.DependencyInjection;
    
public static class DomainServicesDI
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient<ISeedDatabaseService, SeedDatabaseService>();

        return services;
    }
}
