using Microsoft.EntityFrameworkCore;
using OpenGaming.Api.Adapters;
using OpenGaming.Api.Infrastructure;
using OpenGaming.Api.Model;
using OpenGaming.Api.Services;

namespace OpenGaming.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration,
        bool detailedLogging = false)
    {
        var dbSettings = configuration.GetOptions<DbSettings>();
        var connectionString =
            dbSettings.ConnectionString; // configuration.GetConnectionString("DBSettings:ConnectionString");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        // Configure DbContext with Scoped lifetime
        services.AddDbContext<GamingContext>(options =>
            {
                options.UseMySql(connectionString, serverVersion, builder => builder.EnableRetryOnFailure());
                options.EnableDetailedErrors(detailedLogging);
                options.EnableSensitiveDataLogging(detailedLogging);
            }
        );

        return services;
    }

    public static IServiceCollection AddOpenGamingServices(this IServiceCollection services)
    {
        services.AddScoped<IPunterService, PunterService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IRiskService, RiskService>();
        return services;
    }
}