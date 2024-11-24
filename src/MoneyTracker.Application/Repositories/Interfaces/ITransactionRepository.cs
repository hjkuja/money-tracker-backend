using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Repositories.Interfaces;

public interface ITransactionRepository
{
    /// <summary>
    /// Gets <see cref="Transaction"/> by id.
    /// </summary>
    /// <param name="id">Transaction <see cref="Guid"/>.</param>
    /// <param name="token"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Transaction"/> if transaction with id exists, otherwise null.</returns>
    Task<Transaction?> GetByIdAsync(Guid id, CancellationToken token = default);

    /// <summary>
    /// Gets all <see cref="Transaction"/>s belonging to an account.
    /// </summary>
    /// <param name="id">Account <see cref="Guid"/>.</param>
    /// <param name="token"><see cref="CancellationToken"/></param>
    /// <returns>List of account's <see cref="Transaction"/>s.</returns>
    Task<List<Transaction>> GetByAccountIdAsync(Guid id, CancellationToken token = default);
}
