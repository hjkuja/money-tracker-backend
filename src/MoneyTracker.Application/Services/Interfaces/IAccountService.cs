using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories.Interfaces;

namespace MoneyTracker.Application.Services.Interfaces;

public interface IAccountService
{
    /// <inheritdoc cref="IAccountRepository.GetByIdAsync(Guid, CancellationToken)"/>
    Task<Account?> GetByIdAsync(Guid id, CancellationToken token = default);

    /// <inheritdoc cref="IAccountRepository.GetByUserIdAsync(Guid, CancellationToken)"/>
    Task<List<Account>> GetByUserIdAsync(Guid id, CancellationToken token = default);
}
