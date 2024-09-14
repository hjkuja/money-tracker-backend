using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories.Interfaces;

namespace MoneyTracker.Application.Services.Interfaces;

public interface IUserProfileService
{
    /// <inheritdoc cref="IUserProfileRepository.GetByIdAsync(Guid, CancellationToken)"/>
    Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken token = default);
}
