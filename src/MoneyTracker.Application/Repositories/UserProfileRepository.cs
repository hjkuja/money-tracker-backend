using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Application.Database;
using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Repositories;

internal class UserProfileRepository : IUserProfileRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    //private readonly MoneyTrackerContext _context;

    public UserProfileRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MoneyTrackerContext>();

        var account = await db.UserProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (account is null) { return null; }

        return account;
    }
}
