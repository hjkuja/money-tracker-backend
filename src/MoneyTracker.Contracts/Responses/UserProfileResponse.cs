namespace MoneyTracker.Contracts.Responses;

public class UserProfileResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
