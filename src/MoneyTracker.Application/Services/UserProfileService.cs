using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories.Interfaces;
using MoneyTracker.Application.Services.Interfaces;

namespace MoneyTracker.Application.Services;

public class UserProfileService : IUserProfileService
{

    private readonly IUserProfileRepository _userProfileRepository;

    public UserProfileService(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    /// <inheritdoc/>
    public Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _userProfileRepository.GetByIdAsync(id, token);
    }
}
