using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Server.Exceptions;
using Server.Interfaces;
using Server.Models;

namespace Server.Utils;

public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        string? tokenKey = Environment.GetEnvironmentVariable("JWT_SECRET")
            ?? throw new JwtSecretNotFoundException("JWT secret key not found.");

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
