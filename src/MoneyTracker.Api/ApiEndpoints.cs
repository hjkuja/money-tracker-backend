namespace MoneyTracker.Api;

public class ApiEndpoints
{
    public static class Account
    {
        private const string Base = $"accounts";

        public const string Get = $"{Base}/{{id}}";
    }
}
