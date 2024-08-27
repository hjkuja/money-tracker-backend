using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Services;

public interface IUserProfileService
{
    Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken token = default);
}
