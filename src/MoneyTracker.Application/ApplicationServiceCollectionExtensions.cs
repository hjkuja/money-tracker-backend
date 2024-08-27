using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Application.Database;
using MoneyTracker.Application.Repositories;
using MoneyTracker.Application.Services;

namespace MoneyTracker.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAccountServices();
        return services;
    }


    private static IServiceCollection AddAccountServices(this IServiceCollection services)
    {
        // TODO: Singletons cannot use scoped .AddDbContext service
        services.AddSingleton<IUserProfileRepository, UserProfileRepository>();
        services.AddSingleton<IUserProfileService, UserProfileService>();
        return services;
    }

    /// <summary>
    /// Adds database connection to the applications services as a Singleton.
    /// </summary>
    /// <param name="services">Applications <see cref="IServiceCollection"/></param>
    /// <param name="connectionString">SQL database connection string.</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MoneyTrackerContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

#if DEBUG
        services.AddTransient<DbInitializer>();
#endif

        return services;
    }
}
