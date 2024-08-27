using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Application.Models;

public class Account
{
    public Account()
    {

    }

    public Account(Guid ownerId, string accountName)
    {
        UserProfileId = ownerId;
        Name = accountName;
    }

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserProfileId { get; set; }

    [Required]
    public string Name { get; set; } = $"Account_{DateTime.UtcNow}";

    public UserProfile UserProfile { get; set; } = null!;
}
