using MemkaShop.Domain.InfrastructureInterfaces.Persistence.Repositories;
using MemkaShop.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MemkaShop.Core.DependencyInjection;

public static class RepositoryDI
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        
        return services;
    }
}