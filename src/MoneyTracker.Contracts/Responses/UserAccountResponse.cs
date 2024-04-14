namespace MoneyTracker.Contracts.Responses;

public class UserAccountResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
