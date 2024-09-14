using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories.Interfaces;
using MoneyTracker.Application.Services.Interfaces;

namespace MoneyTracker.Application.Services;

public class AccountService : IAccountService
{

    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    /// <inheritdoc/>
    public Task<Account?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _accountRepository.GetByIdAsync(id, token);
    }

    /// <inheritdoc/>
    public Task<List<Account>> GetByUserIdAsync(Guid id, CancellationToken token = default)
    {
        return _accountRepository.GetByUserIdAsync(id, token);
    }
}
