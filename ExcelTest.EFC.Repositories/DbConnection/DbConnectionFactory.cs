using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ExcelTest.EFC.Repositories.DbConnection
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly string _readConnectionStringName;
        private readonly string _writeConnectionStringName;

        public DbConnectionFactory(IConfiguration configuration, string readConnectionStringName, string writeConnectionStringName)
        {
            _configuration = configuration;
            _readConnectionStringName = readConnectionStringName;
            _writeConnectionStringName = writeConnectionStringName;
        }

        public IDbConnection CreateConnectionForRead()
        {
            IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString(_readConnectionStringName));
            connection.Open();
            return connection;
        }

        public IDbConnection CreateConnectionForWrite()
        {
            IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString(_writeConnectionStringName));
            connection.Open();
            return connection;
        }
    }
}
