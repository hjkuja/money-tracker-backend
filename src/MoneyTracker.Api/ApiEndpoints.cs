namespace MoneyTracker.Api;

public class ApiEndpoints
{
    // TODO: Api endpoints for Account entities ("bank" account)
    public static class Account
    {
        private const string Base = $"accounts";

        public const string Get = $"{Base}/{{id}}";
    }
}
