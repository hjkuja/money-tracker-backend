using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTracker.Application.Models;

/// <summary>
/// Types transactions can have.
/// </summary>
public enum TransactionType
{
    Add,
    Remove,
    Move
}

/// <summary>
/// A transaction in <see cref="Account"/>'s collection.
/// </summary>
public class Transaction
{
    
    /// <summary>
    /// Creates a new empty transaction.
    /// </summary>
    public Transaction() { }

    /// <summary>
    /// Creates a new transaction.
    /// </summary>
    /// <param name="type"><see cref="TransactionType"/></param>
    /// <param name="amount">Transaction amount</param>
    public Transaction(TransactionType type, decimal amount)
    {
        Type = type;
        Amount = amount;
    }

    /// <summary>
    /// Creates a new transaction.
    /// </summary>
    /// <param name="type"><see cref="TransactionType"/></param>
    /// <param name="amount">Transaction amount.</param>
    /// <param name="accountId">Transaction account.</param>
    public Transaction(TransactionType type, decimal amount, Guid accountId)
    {
        Type = type;
        Amount = amount;
        AccountId = accountId;
    }

    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();

    public TransactionType Type { get; init; }

    /// <summary>
    /// When the transaction was created.
    /// </summary>
    public DateTimeOffset CreatedAtUtc { get; init; } = DateTimeOffset.UtcNow;

    [Precision(18,2)]
    public decimal Amount { get; init; }

    [ForeignKey(nameof(Account))]
    public Guid AccountId { get; init; }

    public Account Account { get; set; } = null!;
}
