using FluentValidation;
using MemkaShop.Application.Auth.Queries;
using MemkaShop.Domain.Services.Interfaces;

namespace MemkaShop.Application.Auth.UseCases;

public class LoginInteractor(
    IAuthService authService,
    IValidator<LoginQuery> validator)
{
    public async Task<bool> InvokeAsync(LoginQuery query)
    {
        var result = await validator.ValidateAsync(query);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
        
        return await authService.Login(query.ToDomainEntity());
    }
}