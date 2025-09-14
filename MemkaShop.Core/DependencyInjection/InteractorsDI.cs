using MemkaShop.Application.Auth.UseCases;
using MemkaShop.Application.Database.UseCaces;
using Microsoft.Extensions.DependencyInjection;

namespace MemkaShop.Core.DependencyInjection;

public static class InteractorsDI
{
    public static IServiceCollection AddInteractors(this IServiceCollection services)
    {
        services.AddTransient<SeedDatabaseInteractor>();
        services.AddTransient<RegisterInteractor>();
        services.AddTransient<LoginInteractor>();

        return services;
    }
}
