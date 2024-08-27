namespace MoneyTracker.Api;

public class ApiEndpoints
{
    public static class UserProfile
    {
        private const string Base = $"users";

        public const string Get = $"{Base}/{{id}}";
    }
}
