using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Services.Interfaces;
using Scalar.AspNetCore;

namespace MoneyTracker.Api.Endpoints;

internal static class UserEndpoints
{
    private const string BasePath = "users";

    internal static void MapUserEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder
            .MapGroup(BasePath)
            .WithTags("Users");

        group.MapGet("{id}", Get).WithSummary("Get user with id.").WithDescription("Gets user profile with provided id.");
    }

    private static async Task<IResult> Get(Guid id, [FromServices] IUserProfileService userService)
    {

        var user = await userService.GetByIdAsync(id);

        return TypedResults.Ok(user);
    }
}
