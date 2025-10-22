using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Database;

public class DbInitializer
{
    private readonly MoneyTrackerContext _context;

    private static readonly Guid DebugAdminProfileId = Guid.Parse("8eebf12d-d332-11ee-9cdc-0242ac110002");

    private UserProfile? _adminProfile;

    private static readonly List<Transaction> CardTransactions = new()
    {
        new Transaction
        {
            Type = TransactionType.Add,
            Amount = 100,
            CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-10).ToUniversalTime()
        },
        new Transaction
        {
            Type = TransactionType.Remove,
            Amount = 25,
            CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-5).ToUniversalTime()
        }
    };

    private static readonly List<Transaction> SavingsTransactions = new()
    {
        new Transaction
        {
            Type = TransactionType.Remove,
            Amount = 100,
            CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-15).ToUniversalTime()
        },
        new Transaction
        {
            Type = TransactionType.Add,
            Amount = 80,
            CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-10).ToUniversalTime()
        }
    };
    
    private readonly List<Account> _adminAccounts = new()
    {
        new Account(DebugAdminProfileId, "Card account")
        {
            Balance = 200 + CardTransactions.Sum(t => t.Amount),
            Transactions = CardTransactions
        },
        new Account(DebugAdminProfileId, "Savings")
        {
            Balance = 6543.21M + SavingsTransactions.Sum(t => t.Amount),
            Transactions = SavingsTransactions
        }
    };

    public DbInitializer(MoneyTrackerContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Initializes the database context.
    /// </summary>
    /// <returns>Task to initialize the database.</returns>
    public async Task InitializeAsync()
    {
        await _context.Database.MigrateAsync();

        await AddAdminProfileAsync();
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Adds admin user to database if not found.
    /// </summary>
    private async Task AddAdminProfileAsync()
    {
        _adminProfile = _context.UserProfiles.AsNoTracking().FirstOrDefault(acc => acc.Id == DebugAdminProfileId);

        if (_adminProfile is null)
        {
            _adminProfile = new UserProfile("Admin")
            {
                Id = DebugAdminProfileId
            };
            
            await _context.UserProfiles.AddAsync(_adminProfile);
        };
        
        await AddAdminAccountsWithTransactionsAsync();
    }

    /// <summary>
    /// Adds accounts with some transactions to database.
    /// </summary>
    private async Task AddAdminAccountsWithTransactionsAsync()
    {
        var adminAccounts = await _context.Accounts.AsNoTracking().Where(x => x.UserProfileId == DebugAdminProfileId).ToListAsync();

        if (adminAccounts.Count != 0)
        {
            _adminAccounts.AddRange(adminAccounts);
            return;
        }
        
        await _context.Accounts.AddRangeAsync(_adminAccounts);
    }
}
