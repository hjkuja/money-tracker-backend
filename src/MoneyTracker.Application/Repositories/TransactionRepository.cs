using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Application.Database;
using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories.Interfaces;

namespace MoneyTracker.Application.Repositories;

internal class TransactionRepository : ITransactionRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public TransactionRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <inheritdoc/>
    public async Task<Transaction?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MoneyTrackerContext>();

        return await db.Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);
    }

    /// <inheritdoc/>
    public async Task<List<Transaction>> GetByAccountIdAsync(Guid id, CancellationToken token = default)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MoneyTrackerContext>();

        return await db.Transactions
            .AsNoTracking()
            .Where(t => t.AccountId == id)
            .ToListAsync(cancellationToken: token);
    }
}
