using MemkaShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MemkaShop.Core.DependencyInjection;

public static class SecurityDI
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
        
        return services;
    }
}