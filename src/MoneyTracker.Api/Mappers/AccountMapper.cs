using MoneyTracker.Application.Models;
using MoneyTracker.Contracts.Responses;

namespace MoneyTracker.Api.Mappers;

public static class AccountMapper
{
    public static AccountResponse MapToResponse(this Account account)
    {
        return new AccountResponse 
        { 
            Id = account.Id,
            Name = account.Name
        };
    }
}
