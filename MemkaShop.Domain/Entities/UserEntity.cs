namespace MemkaShop.Domain.Entities;

public class UserEntity
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public HashSet<RoleEntity> Roles { get; set; } = new();
}