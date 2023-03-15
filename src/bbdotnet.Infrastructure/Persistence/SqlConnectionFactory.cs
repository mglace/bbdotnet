using bbdotnet.Application.Abstractions;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace bbdotnet.Infrastructure.Persistence;

internal class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbConnection CreateConnection() => new SqlConnection(_connectionString);
}
