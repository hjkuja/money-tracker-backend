using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Repositories;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken token = default);
}
