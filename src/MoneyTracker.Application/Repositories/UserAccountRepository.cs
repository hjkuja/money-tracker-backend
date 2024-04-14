using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Application.Database;
using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Repositories;

internal class UserAccountRepository : IUserAccountRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    //private readonly MoneyTrackerContext _context;

    public UserAccountRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<UserAccount?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MoneyTrackerContext>();

        var account = await db.UserAccounts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (account is null) { return null; }

        return account;
    }
}
