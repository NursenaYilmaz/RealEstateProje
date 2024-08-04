using System.Data;

namespace REALESTATE_DAPPER_API.Models.dappercontext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection() => new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
    }
}
