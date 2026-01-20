using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Application.Database;
using MoneyTracker.Application.Repositories;
using MoneyTracker.Application.Repositories.Interfaces;
using MoneyTracker.Application.Services;
using MoneyTracker.Application.Services.Interfaces;

namespace MoneyTracker.Application;

public static class ApplicationServiceCollectionExtensions
{
    /// <summary>
    /// Adds the application services to the provided <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to modify.</param>
    /// <returns>The <see cref="IServiceCollection"/> with the added services.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAccountServices();
        return services;
    }

    private static IServiceCollection AddAccountServices(this IServiceCollection services)
    {
        // User
        services.AddSingleton<IUserProfileRepository, UserProfileRepository>();
        services.AddSingleton<IUserProfileService, UserProfileService>();

        // Account
        services.AddSingleton<IAccountRepository, AccountRepository>();
        services.AddSingleton<IAccountService, AccountService>();

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
        services.AddDbContext<MoneyTrackerContext>(options =>
        {
            options.UseNpgsql(connectionString);
#if DEBUG
            options.EnableSensitiveDataLogging();
#endif
        });

#if DEBUG
        services.AddTransient<DbInitializer>();
#endif

        return services;
    }
}
