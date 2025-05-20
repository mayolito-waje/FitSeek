using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Interfaces;
using Server.Utils;

namespace Server.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
