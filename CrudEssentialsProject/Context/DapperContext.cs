using MySqlConnector;
using System.Data;

namespace CrudEssentialsProject.Context
{
    public class DapperContext
    {
        private readonly string? _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        public IDbConnection getConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}

