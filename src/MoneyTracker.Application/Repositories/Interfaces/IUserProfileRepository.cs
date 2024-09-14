using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Repositories.Interfaces;

public interface IUserProfileRepository
{
    /// <summary>
    /// Get <see cref="UserProfile"/> by their id.
    /// </summary>
    /// <param name="id">User <see cref="Guid"/>.</param>
    /// <param name="token"><see cref="CancellationToken"/></param>
    /// <returns><see cref="UserProfile"/> if user with provided id exists, otherwise null.</returns>
    Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken token = default);
}
