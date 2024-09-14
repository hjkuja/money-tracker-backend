using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MoneyTracker.Contracts.Responses;

public class UserProfileResponse
{
    public required Guid Id { get; set; }

    [Required]
    public required string Name { get; set; }
}
