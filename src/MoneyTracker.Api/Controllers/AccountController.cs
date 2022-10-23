using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Api.Context;
using MoneyTracker.Api.Models;
using System.Net;

namespace MoneyTracker.Api.Controllers
{
    /// <summary>
    /// Account controller
    /// </summary>
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private MoneyTrackerContext _db;

        public AccountController(MoneyTrackerContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get user account info.
        /// </summary>
        /// <param name="id">User's id.</param>
        /// <returns>User account.</returns>
        [HttpGet]
        public async Task<ActionResult<AccountDTO>> Get(int id)
        {
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == id);

            if (account == null) return NotFound("User not found.");

            return Ok(account.ToDTO());
        }

        /// <summary>
        /// Endpoint for user to create an account.
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        public ActionResult CreateAccount(AccountDTO account)
        {
            return Ok(account.Username);
        }

    }
}
