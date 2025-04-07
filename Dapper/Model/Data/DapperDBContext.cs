using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
namespace Dapper.Model.Data
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public DapperDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
