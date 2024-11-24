using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Database;

public class DbInitializer
{
    private readonly MoneyTrackerContext _context;

    private readonly Guid _debugAdminProfileId = Guid.Parse("8eebf12d-d332-11ee-9cdc-0242ac110002");

    private UserProfile? _adminProfile  = null;
    private List<Account> _adminAccounts = new List<Account>();

    public DbInitializer(MoneyTrackerContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {

        _adminProfile = await AddAdminProfileAsync();
        _adminAccounts = await AddAdminAccountsWithTransactionsAsync();

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Adds admin user to database if not found
    /// </summary>
    /// <returns></returns>
    private async Task<UserProfile> AddAdminProfileAsync()
    {
        var adminProfile = _context.UserProfiles.AsNoTracking().FirstOrDefault(acc => acc.Id == _debugAdminProfileId);

        if (adminProfile != null) return adminProfile;

        adminProfile = new UserProfile("Admin");
        adminProfile.Id = _debugAdminProfileId;

        await _context.UserProfiles.AddAsync(adminProfile);
        return adminProfile;
    }

    private async Task<List<Account>> AddAdminAccountsWithTransactionsAsync()
    {
        var adminAccounts = await _context.Accounts.AsNoTracking().Where(x => x.UserProfileId == _debugAdminProfileId).ToListAsync();

        // If db already has some accounts, return them.
        if (adminAccounts.Count != 0)
        {
            _adminAccounts.AddRange(adminAccounts);
            return adminAccounts;
        }

        // Otherwise, initialize test accounts

        var accountList = new List<Account>()
        {
            new(_debugAdminProfileId, "Card account"),
            new(_debugAdminProfileId, "Savings")
        };

        await _context.Accounts.AddRangeAsync(accountList);
        return accountList;
    }
}
