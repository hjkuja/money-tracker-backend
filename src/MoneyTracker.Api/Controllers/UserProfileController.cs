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


    /// <summary>
    /// Gets a user profile by id.
    /// </summary>
    /// <param name="id">User id.</param>
    /// <returns><see cref="UserProfileResponse"/> if user is found. Otherwise not found.</returns>
    [HttpGet(ApiEndpoints.UserProfile.Get)]
    [ProducesResponseType(typeof(UserProfileResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var userProfile = await _userProfileService.GetByIdAsync(id);

        if (userProfile is null) return NotFound();

        return Ok(userProfile.MapToResponse());
    }

    /// <summary>
    /// Gets all accounts for a user.
    /// </summary>
    /// <param name="id">User's id.</param>
    /// <returns>List of user's accounts.</returns>
    [HttpGet(ApiEndpoints.UserProfile.GetAccounts)]
    [ProducesResponseType(typeof(List<AccountResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByUserId([FromRoute] Guid id)
    {
        var userAccounts = await _accountService.GetByUserIdAsync(id);

        return Ok(userAccounts.Select(x => x.MapToResponse()).ToList());
    }
}
