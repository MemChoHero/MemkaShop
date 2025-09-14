using MemkaShop.Domain.Entities;

namespace MemkaShop.Domain.Services.Interfaces;

public interface IAuthService
{
    Task<UserEntity> Register(UserEntity userEntity, RoleEntity roleEntity);
    Task<bool> Login(UserEntity userEntity);
}