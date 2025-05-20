using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Server.Exceptions;

namespace Server.Extensions;

public static class JwtServiceExtensions
{
    public static IServiceCollection AddTokenExtractor(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                string? tokenKey = Environment.GetEnvironmentVariable("JWT_SECRET")
                    ?? throw new JwtSecretNotFoundException("JWT secret key not found.");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey))
                };
            });

        return services;
    } 
}
