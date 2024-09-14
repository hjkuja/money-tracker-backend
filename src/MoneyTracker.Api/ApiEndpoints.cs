namespace MoneyTracker.Api;

public class ApiEndpoints
{
    public static class UserProfile
    {
        private const string Base = $"users";

        public const string Get = $"{Base}/{{id}}";
        public const string GetAccounts = $"{Base}/{{id}}/accounts";
    }

    public static class Account
    {
        private const string Base = $"accounts";

        public const string Get = $"{Base}/{{id}}";
    }
}
