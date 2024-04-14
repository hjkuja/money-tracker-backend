using MySqlConnector;
using System.Data;

namespace MoneyTracker.Application.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
}

public class MariaConnectionFactory : IDbConnectionFactory
{

    private readonly string _connectionString;

    public MariaConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Creates a connection to provided sql server.
    /// </summary>
    /// <param name="token"><see cref="CancellationToken"/></param>
    /// <returns>Opened connection</returns>
    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default)
    {

        var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}