using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Database;

public class DbInitializer
{
    private readonly MoneyTrackerContext _context;

    public Guid AdminAccountId { get; } = Guid.Parse("8eebf12d-d332-11ee-9cdc-0242ac110002");

    public DbInitializer(MoneyTrackerContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {

        await AddAdminAsync();
        
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Adds admin user to database if not found
    /// </summary>
    /// <returns></returns>
    private async Task AddAdminAsync()
    {
        var adminAccount = _context.UserAccounts.AsNoTracking().FirstOrDefault(acc => acc.Id == AdminAccountId);

        if (adminAccount != null) return;

        adminAccount = new UserAccount("Admin");
        adminAccount.Id = AdminAccountId;

        await _context.UserAccounts.AddAsync(adminAccount);
    }
}
