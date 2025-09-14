using MemkaShop.Domain.Entities;

namespace MemkaShop.Application.Auth.Queries;

public class LoginQuery
{
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;

    public UserEntity ToDomainEntity()
    {
        return new UserEntity()
        {
            Email = Email,
            Password = Password
        };
    }
}