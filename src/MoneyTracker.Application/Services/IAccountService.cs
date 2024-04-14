using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Services;

public interface IAccountService
{
    Task<UserAccount?> GetByIdAsync(Guid id, CancellationToken token = default);
}
