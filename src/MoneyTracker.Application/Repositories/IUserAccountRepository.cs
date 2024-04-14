using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Repositories;

internal interface IUserAccountRepository
{
    Task<UserAccount?> GetByIdAsync(Guid id, CancellationToken token = default);
}
