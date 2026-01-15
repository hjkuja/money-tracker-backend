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
        await CheckEFMigrationsAsync();
        await _context.Database.MigrateAsync();

        await AddAdminProfileAsync();
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Check and initialize EF migrations table if not found
    /// </summary>
    /// <returns>Task to check and initialize EF migrations table.</returns
    private async Task CheckEFMigrationsAsync()
    {
        //DbConnection conn;
        var conn = _context.Database.GetDbConnection();
        try
        {
            if (conn is null)
            {
                throw new Exception("Failed to connect to DB");
            }

            if (conn.State is not System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = '__EFMigrationsHistory');";
            var exists = await cmd.ExecuteScalarAsync();

            if (exists is true) return;

            cmd.CommandText = "CREATE TABLE \"__EFMigrationsHistory\" (\"MigrationId\" character varying(150) NOT NULL, \"ProductVersion\" character varying(32) NOT NULL, CONSTRAINT \"PK___EFMigrationsHistory\" PRIMARY KEY (\"MigrationId\"));";
            await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            // Because we're in development mode, just write the exception to console
            Console.WriteLine(ex);
            throw;
        }
        finally
        {
            conn.Dispose();
        }
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
