using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Services.Interfaces;
using Scalar.AspNetCore;

namespace MoneyTracker.Api.Endpoints;

internal static class AccountEndpoints
{
    private const string BasePath = "accounts";

    internal static void MapAccountEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder
            .MapGroup(BasePath)
            .WithTags("Accounts");

        group.MapGet("{id}", Get).WithSummary("Get account with id.").WithDescription("Gets account info with provided id.");
    }

    private static async Task<IResult> Get(Guid id, [FromServices] IAccountService accountService)
    {

        var account = await accountService.GetByIdAsync(id);

        return TypedResults.Ok(account);
    }
}
