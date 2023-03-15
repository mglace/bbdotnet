using System.Data.Common;

namespace bbdotnet.Application.Abstractions;

public interface ISqlConnectionFactory
{
    DbConnection CreateConnection();
}
