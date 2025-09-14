using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MemkaShop.WebApi.Settings;

public class AuthOptions
{
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public string SecurityKey { get; init; } = null!;

    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
    }
}