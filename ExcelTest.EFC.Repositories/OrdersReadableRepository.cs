using Dapper;
using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.EFC.Repositories.DbConnection;
using System.Data;

namespace ExcelTest.EFC.Repositories
{
    public class OrdersReadableRepository : IReadableOrdersRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public OrdersReadableRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async ValueTask<bool> ExistOrder(Order order)
        {
            using (var connection = _connectionFactory.CreateConnectionForRead())
            {

                const string sql = "SELECT COUNT(*) FROM Orders WHERE Id = @Id";

                var count = await connection.QuerySingleAsync<int>(sql, new { order.Id });

                return count > 0;
            }
        }

        public async Task SaveChanges()
        {
            //dapper no necesita hacer un SaveChanges()
        }
    }
}
