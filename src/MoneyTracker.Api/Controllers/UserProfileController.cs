using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Api.Mappers;
using MoneyTracker.Application.Services.Interfaces;
using MoneyTracker.Contracts.Responses;
using System.Net;

namespace MoneyTracker.Api.Controllers;

[ApiController]
[Produces("application/json")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;
    private readonly IAccountService _accountService;

    public UserProfileController(IUserProfileService userProfileService, IAccountService accountService)
    {
        _userProfileService = userProfileService;
        _accountService = accountService;
    }

    
    [HttpGet(ApiEndpoints.UserProfile.Get)]
    [ProducesResponseType(typeof(UserProfileResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var userProfile = await _userProfileService.GetByIdAsync(id);

        if (userProfile is null) return NotFound();

        return Ok(userProfile.MapToResponse());
    }

    [HttpGet(ApiEndpoints.UserProfile.GetAccounts)]
    [ProducesResponseType(typeof(List<AccountResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByUserId([FromRoute] Guid id)
    {
        var userAccounts = await _accountService.GetByUserIdAsync(id);

        return Ok(userAccounts.Select(x => x.MapToResponse()).ToList());
    }
}
