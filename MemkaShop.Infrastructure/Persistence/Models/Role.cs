using MemkaShop.Domain.Entities;
using MemkaShop.Infrastructure.Persistence.Interfaces;

namespace MemkaShop.Infrastructure.Persistence.Models;

public class Role : IHasTimestamps
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public HashSet<User> Users { get; set; } = new();

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public RoleEntity ToDomainEntity()
    {
        return new RoleEntity()
        {
            Name = Name!,
        };
    }

    public static Role FromDomainEntity(RoleEntity domainEntity)
    {
        return new Role()
        {
            Name = domainEntity.Name,
        };
    }
}