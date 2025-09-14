using MemkaShop.Application.Auth.Queries;
using MemkaShop.Application.Auth.Responses;
using MemkaShop.Domain.Services.Interfaces;

namespace MemkaShop.Application.Auth.UseCases;

public class LoginInteractor(IAuthService authService)
{
    public async Task<bool> InvokeAsync(LoginQuery query)
    {
        return await authService.Login(query.ToDomainEntity());
    }
}