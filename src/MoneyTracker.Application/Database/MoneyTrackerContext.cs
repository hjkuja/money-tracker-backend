using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Models;

namespace MoneyTracker.Application.Database;

public class MoneyTrackerContext : DbContext
{
    public MoneyTrackerContext(DbContextOptions<MoneyTrackerContext> options) : base(options)
    {
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Account> Accounts { get; set; }
}
