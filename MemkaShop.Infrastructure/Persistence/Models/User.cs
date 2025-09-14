using MemkaShop.Domain.Entities;
using MemkaShop.Infrastructure.Persistence.Interfaces;

namespace MemkaShop.Infrastructure.Persistence.Models;

public class User : IHasTimestamps
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    
    public HashSet<Role> Roles { get; set; } = new();

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserEntity ToDomainEntity()
    {
        return new UserEntity()
        {
            Username = Name!,
            Email = Email!,
            Password = Password!,
            Roles = Roles.Select(r => r.ToDomainEntity()).ToHashSet()
        };
    }

    public static User FromDomainEntity(UserEntity userEntity)
    {
        return new User()
        {
            Name = userEntity.Username,
            Email = userEntity.Email,
            Password = userEntity.Password,
        };
    }
}