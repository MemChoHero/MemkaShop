using MemkaShop.Domain.Entities;

namespace MemkaShop.Application.Auth.Responses;

public class RegisterResponse
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } =  null!;
    public string Password { get; set; } =  null!;
    
    public HashSet<string> Roles { get; set; } = new HashSet<string>();

    public static RegisterResponse FromDomainEntity(UserEntity userEntity)
    {
        return new RegisterResponse()
        {
            Name = userEntity.Username,
            Email = userEntity.Email,
            Password = userEntity.Password,
            Roles = userEntity.Roles.Select(r => r.Name).ToHashSet()
        };
    }
}