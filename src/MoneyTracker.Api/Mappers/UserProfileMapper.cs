using MoneyTracker.Application.Models;
using MoneyTracker.Contracts.Responses;

namespace MoneyTracker.Api.Mappers;

/// <summary>
/// Contains mappers for <see cref="UserProfile"/>
/// </summary>
public static class UserProfileMapper
{
    public static UserProfileResponse MapToResponse(this UserProfile account)
    {
        return new UserProfileResponse
        {
            Id = account.Id,
            Name = account.Name
        };

    }
}
