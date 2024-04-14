using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Api.Mappers;
using MoneyTracker.Application.Services;
using MoneyTracker.Contracts.Responses;
using System.Net;

namespace MoneyTracker.Api.Controllers;

[ApiController]
[Produces("application/json")]
public class UserAccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public UserAccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [ProducesResponseType(typeof(UserAccountResponse), (int)HttpStatusCode.OK)]
    [HttpGet(ApiEndpoints.Account.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var account = await _accountService.GetByIdAsync(id);

        if (account is null) return NotFound();

        return Ok(account.MapToResponse());
    }
}
