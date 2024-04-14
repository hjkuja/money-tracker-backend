using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Database;

public class MoneyTrackerContext : DbContext
{
    public MoneyTrackerContext(DbContextOptions<MoneyTrackerContext> options) : base(options)
    {
    }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Account> Account { get; set; }
}
