using DotNetEnv;
using Server.Extensions;

// Load env file
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddTokenExtractor();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins(
        "http://127.0.0.1:4200", "https://127.0.0.1:4200", "http://localhost:4200", "https://localhost:4200"
    ));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
