using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Application.Database;
using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories.Interfaces;

namespace MoneyTracker.Application.Repositories;

internal class AccountRepository : IAccountRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public AccountRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <inheritdoc/>
    public async Task<Account?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MoneyTrackerContext>();

        return await db.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);
    }

    /// <inheritdoc/>
    public async Task<List<Account>> GetByUserIdAsync(Guid id, CancellationToken token = default)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MoneyTrackerContext>();

        return await db.Accounts
            .AsNoTracking()
            .Where(account => account.UserProfileId == id)
            .ToListAsync(cancellationToken: token);
    }
}
