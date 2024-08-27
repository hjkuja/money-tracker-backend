using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Api.Mappers;
using MoneyTracker.Application.Services;
using MoneyTracker.Contracts.Responses;
using System.Net;

namespace MoneyTracker.Api.Controllers;

[ApiController]
[Produces("application/json")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;

    public UserProfileController(IUserProfileService userProfileService)
    {
        _userProfileService = userProfileService;
    }

    [ProducesResponseType(typeof(UserProfileResponse), (int)HttpStatusCode.OK)]
    [HttpGet(ApiEndpoints.UserProfile.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var account = await _userProfileService.GetByIdAsync(id);

        if (account is null) return NotFound();

        return Ok(account.MapToResponse());
    }
}
