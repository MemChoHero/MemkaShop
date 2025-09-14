using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MemkaShop.WebApi.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MemkaShop.WebApi.Jwt;

public class JwtProcessor(IOptions<AuthOptions> authOptions)
{
    public string Encode(string email, TimeSpan lifetime)
    {
        var claims = new List<Claim> { new(ClaimTypes.Email, email) };

        var jwt = new JwtSecurityToken(
            issuer: authOptions.Value.Issuer,
            audience: authOptions.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(lifetime),
            signingCredentials: new SigningCredentials(
                authOptions.Value.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public string Validate(string token)
    {
        return new JwtSecurityTokenHandler()
            .ReadJwtToken(token).Claims
            .First(c => c.Type == ClaimTypes.Email).Value;
    }
}