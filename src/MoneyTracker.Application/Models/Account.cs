using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Application.Models;

public class Account
{
    public Account() { }

    public Account(Guid ownerId)
    {
        UserProfileId = ownerId;
    }

    public Account(Guid ownerId, string accountName)
    {
        UserProfileId = ownerId;
        Name = accountName;
    }

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserProfileId { get; set; }

    public string Name { get; set; } = $"Account_{DateTime.UtcNow}";

    public DateTimeOffset CreatedAtUtc { get; set; } = DateTimeOffset.UtcNow;

    public UserProfile UserProfile { get; set; } = null!;

    [Precision(18, 2)]
    public decimal Balance { get; set; } = 0M;

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
