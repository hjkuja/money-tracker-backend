
using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Contracts.Responses;

public class AccountResponse
{
    public required Guid Id { get; set; }

    [Required]
    public required string Name { get; set; }
}
