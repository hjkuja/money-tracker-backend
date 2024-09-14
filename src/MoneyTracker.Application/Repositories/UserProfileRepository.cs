using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Application.Database;
using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories.Interfaces;

namespace MoneyTracker.Application.Repositories;

internal class UserProfileRepository : IUserProfileRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public UserProfileRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <inheritdoc/>
    public async Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MoneyTrackerContext>();

        var userProfile = await db.UserProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);

        if (userProfile is null) { return null; }

        return userProfile;
    }
}
