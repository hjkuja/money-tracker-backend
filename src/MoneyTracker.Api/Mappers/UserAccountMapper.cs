using MoneyTracker.Application.Models;
using MoneyTracker.Contracts.Responses;

namespace MoneyTracker.Api.Mappers;

/// <summary>
/// Contains mappers for <see cref="UserAccount"/>
/// </summary>
public static class UserAccountMapper
{
    public static UserAccountResponse MapToResponse(this UserAccount account)
    {
        return new UserAccountResponse
        {
            Id = account.Id,
            Name = account.Name
        };

    }
}
