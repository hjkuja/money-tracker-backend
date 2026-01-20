namespace MoneyTracker.Api.Endpoints;

internal static class EndpointExtensions
{
    /// <summary>
    /// Adds endpoints to <see cref="IEndpointRouteBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IEndpointRouteBuilder"/> to operate on.</param>
    /// <returns>The <see cref="IEndpointRouteBuilder"/>.</returns>
    internal static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapAccountEndpoints();
        builder.MapUserEndpoints();
        return builder;
    }
}
