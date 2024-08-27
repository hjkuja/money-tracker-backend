using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Repositories;

internal interface IUserProfileRepository
{
    Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken token = default);
}
