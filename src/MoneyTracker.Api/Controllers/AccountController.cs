using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Api.Mappers;
using MoneyTracker.Application.Services.Interfaces;
using MoneyTracker.Contracts.Responses;
using System.Net;

namespace MoneyTracker.Api.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet(ApiEndpoints.Account.Get)]
    [ProducesResponseType(typeof(AccountResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var account = await _accountService.GetByIdAsync(id);
        
        if (account is null) return NotFound();

        return Ok(account.MapToResponse());
    }
}
