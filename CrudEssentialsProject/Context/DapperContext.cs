using MySqlConnector;
using System.Data;

namespace CrudEssentialsProject.Context
{
    public class DapperContext
    {
        private readonly string? _connectionString;
        private readonly ILogger<DapperContext> _logger;

        public DapperContext(IConfiguration configuration, ILogger<DapperContext> logger)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        public IDbConnection GetConnection()
        {
            _logger.LogInformation("Connecting to database");
            var conn = new MySqlConnection(_connectionString);
            _logger.LogInformation("Connected to database");

            return conn;
        }
    }
}

