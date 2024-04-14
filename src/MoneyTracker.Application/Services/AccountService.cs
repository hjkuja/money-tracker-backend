using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories;

namespace MoneyTracker.Application.Services;

internal class AccountService : IAccountService
{

    private readonly IUserAccountRepository _accountRepository;

    public AccountService(IUserAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Task<UserAccount?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _accountRepository.GetByIdAsync(id, token);
    }
}
