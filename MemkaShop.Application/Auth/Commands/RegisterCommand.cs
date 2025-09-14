using MemkaShop.Domain.Entities;

namespace MemkaShop.Application.Auth.Commands;

public class RegisterCommand
{
    public string Name { get; init; } = null!;
    public string Email { get; init; } =  null!;
    public string Password { get; init; } =  null!;

    public UserEntity ToDomainEntity()
    {
        return new UserEntity()
        {
            Username = Name,
            Email = Email,
            Password = Password
        };
    }
}