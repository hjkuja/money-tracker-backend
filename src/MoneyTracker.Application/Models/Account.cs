using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Application.Models;

public class Account
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserAccountId { get; set; }

    public UserAccount UserAccount { get; set; } = null!;
}
