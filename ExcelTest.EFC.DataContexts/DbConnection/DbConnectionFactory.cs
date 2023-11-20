using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ExcelTest.EFC.DataContexts.DbConnection
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration configuration;
        private readonly string readConnectionStringName;
        private readonly string writeConnectionStringName;

        public DbConnectionFactory(IConfiguration configuration, string readConnectionStringName, string writeConnectionStringName)
        {
            this.configuration = configuration;
            this.readConnectionStringName = readConnectionStringName;
            this.writeConnectionStringName = writeConnectionStringName;
        }

        public IDbConnection CreateConnectionForRead()
        {
            IDbConnection connection = new MySqlConnection(this.configuration.GetConnectionString(this.readConnectionStringName));
            connection.Open();
            return connection;
        }

        public IDbConnection CreateConnectionForWrite()
        {
            IDbConnection connection = new MySqlConnection(this.configuration.GetConnectionString(this.writeConnectionStringName));
            connection.Open();
            return connection;
        }
    }
}
