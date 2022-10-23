using Microsoft.EntityFrameworkCore;
using MoneyTracker.Api.Context.Entities;

namespace MoneyTracker.Api.Context
{
    public class MoneyTrackerContext : DbContext
    {
        public MoneyTrackerContext(DbContextOptions options) : base(options) { }

        public DbSet<Account> Accounts => Set<Account>();
    }
}
