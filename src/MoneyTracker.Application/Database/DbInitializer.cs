using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Database;

public class DbInitializer
{
    private readonly MoneyTrackerContext _context;

    public Guid DebugAdminProfileId { get; } = Guid.Parse("8eebf12d-d332-11ee-9cdc-0242ac110002");

    private UserProfile? AdminProfile { get; set; } = null;
    private List<Account> AdminAccounts = new List<Account>();

    public DbInitializer(MoneyTrackerContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {

        AdminProfile = await AddAdminProfileAsync();
        AdminAccounts = await AddAdminAccountsAsync();

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Adds admin user to database if not found
    /// </summary>
    /// <returns></returns>
    private async Task<UserProfile> AddAdminProfileAsync()
    {
        var adminProfile = _context.UserProfiles.AsNoTracking().FirstOrDefault(acc => acc.Id == DebugAdminProfileId);

        if (adminProfile != null) return adminProfile;

        adminProfile = new UserProfile("Admin");
        adminProfile.Id = DebugAdminProfileId;

        await _context.UserProfiles.AddAsync(adminProfile);
        return adminProfile;
    }

    private async Task<List<Account>> AddAdminAccountsAsync()
    {
        var adminAccounts = await _context.Accounts.AsNoTracking().Where(x => x.UserProfileId == DebugAdminProfileId).ToListAsync();

        // If db already has some accounts, return them.
        if(adminAccounts.Any()) return adminAccounts;

        // Otherwise, initialize test accounts

        var accountList = new List<Account>()
        {
            new(DebugAdminProfileId, "Card account"),
            new(DebugAdminProfileId, "Savings")
        };

        await _context.Accounts.AddRangeAsync(accountList);
        return accountList;
    }
}
