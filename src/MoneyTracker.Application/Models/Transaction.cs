using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTracker.Application.Models;

public enum TransactionType
{
    Add,
    Remove,
    Move
}

public class Transaction
{
    public Transaction() { }

    public Transaction(TransactionType type, decimal amount, Guid accountId)
    {
        Type = type;
        Amount = amount;
        AccountId = accountId;
    }

    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();

    public TransactionType Type { get; init; }

    public DateTimeOffset CreatedAtUtc { get; init; } = DateTimeOffset.UtcNow;

    [Precision(18,2)]
    public decimal Amount { get; init; }

    [ForeignKey(nameof(Account))]
    public Guid AccountId { get; init; }

    public Account Account { get; set; } = null!;
}
