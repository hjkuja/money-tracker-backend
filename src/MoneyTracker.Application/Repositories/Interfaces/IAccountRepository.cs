using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Repositories.Interfaces;

public interface IAccountRepository
{
    /// <summary>
    /// Gets <see cref="Account"/> by id.
    /// </summary>
    /// <param name="id">Account <see cref="Guid"/>.</param>
    /// <param name="token"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Account"/> if account with id exists, otherwise null.</returns>
    Task<Account?> GetByIdAsync(Guid id, CancellationToken token = default);

    /// <summary>
    /// Gets all <see cref="Account"/>s belonging to user.
    /// </summary>
    /// <param name="id">User <see cref="Guid"/>.</param>
    /// <param name="token"><see cref="CancellationToken"/></param>
    /// <returns>List of user's <see cref="Account"/>s.</returns>
    Task<List<Account>> GetByUserIdAsync(Guid id, CancellationToken token = default);
}
