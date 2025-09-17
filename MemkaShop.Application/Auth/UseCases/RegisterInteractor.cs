using FluentValidation;
using MemkaShop.Application.Auth.Commands;
using MemkaShop.Application.Auth.Responses;
using MemkaShop.Domain;
using MemkaShop.Domain.Entities;
using MemkaShop.Domain.Services.Interfaces;

namespace MemkaShop.Application.Auth.UseCases;

public class RegisterInteractor(
    IAuthService authService,
    IValidator<RegisterCommand> validator)
{
    public async Task<RegisterResponse> InvokeAsync(RegisterCommand command)
    {
        var result = await validator.ValidateAsync(command);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
        
        var userEntity = await authService.Register(
            command.ToDomainEntity(), 
            new RoleEntity() { Name = nameof(RoleEnum.User) });
        
        return RegisterResponse.FromDomainEntity(userEntity);
    }
}