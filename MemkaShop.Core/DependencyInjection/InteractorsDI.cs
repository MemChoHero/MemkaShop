using MemkaShop.Application.Database.UseCaces;
using Microsoft.Extensions.DependencyInjection;

namespace MemkaShop.Core.DependencyInjection;

public static class InteractorsDI
{
    public static IServiceCollection AddInteractors(this IServiceCollection services)
    {
        services.AddTransient<SeedDatabaseInteractor, SeedDatabaseInteractor>();

        return services;
    }
}
