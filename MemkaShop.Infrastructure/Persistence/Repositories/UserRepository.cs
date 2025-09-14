using MemkaShop.Domain.Entities;
using MemkaShop.Domain.InfrastructureInterfaces.Persistence.Repositories;
using MemkaShop.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MemkaShop.Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public async Task<UserEntity?> FindByEmail(string email)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == email);

        return user?.ToDomainEntity();
    }

    public async Task<UserEntity> Create(UserEntity userEntity, RoleEntity roleEntity)
    {
        var user = User.FromDomainEntity(userEntity);
        var role = Role.FromDomainEntity(roleEntity);
        
        var transaction = await db.Database.BeginTransactionAsync();
        
        await db.Roles.AddAsync(role);
        await db.SaveChangesAsync();

        user.Roles.Add(role);
        
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();
        await transaction.CommitAsync();

        return user.ToDomainEntity();
    }
}