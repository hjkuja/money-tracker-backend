namespace MoneyTracker.Api.Exceptions
{
    public class CustomExceptions
    {
        /// <summary>
        /// Custom error for missing configurations.
        /// </summary>
        [Serializable]
        public class MissingConfigurationException : Exception
        {
            public MissingConfigurationException() { }
            public MissingConfigurationException(string message) : base(message) { }
            public MissingConfigurationException(string message, Exception inner) : base(message, inner) { }
        }
    }
}
