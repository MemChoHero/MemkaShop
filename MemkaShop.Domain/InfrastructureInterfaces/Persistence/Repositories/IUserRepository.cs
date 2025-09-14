using MemkaShop.Domain.Entities;

namespace MemkaShop.Domain.InfrastructureInterfaces.Persistence.Repositories;

public interface IUserRepository
{
    Task<UserEntity?> FindByEmail(string email);
    Task<UserEntity> Create(UserEntity userEntity, RoleEntity roleEntity);
}