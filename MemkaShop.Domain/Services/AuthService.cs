using MemkaShop.Domain.Entities;
using MemkaShop.Domain.InfrastructureInterfaces.Persistence.Repositories;
using MemkaShop.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MemkaShop.Domain.Services;

public class AuthService(
    IUserRepository userRepository,
    IPasswordHasher<UserEntity> passwordHasher) : IAuthService
{
    public async Task<UserEntity> Register(UserEntity userEntity, RoleEntity roleEntity)
    {
        userEntity.Password = passwordHasher.HashPassword(userEntity, userEntity.Password);
        
        return await userRepository.Create(userEntity, roleEntity);
    }

    public async Task<bool> Login(UserEntity userEntity)
    {
        var res = await userRepository.FindByEmail(userEntity.Email);
        if (res == null)
            return false;
        
        var checkRes = passwordHasher.VerifyHashedPassword(res, res.Password, userEntity.Password);
        
        return checkRes == PasswordVerificationResult.Success;
    }
}