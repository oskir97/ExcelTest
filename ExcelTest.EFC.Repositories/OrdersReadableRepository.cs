using Dapper;
using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.Dtos.Common;
using ExcelTest.Dtos.GetOrders;
using ExcelTest.EFC.Repositories.DbConnection;
using Org.BouncyCastle.Asn1.Ocsp;
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

        public async ValueTask<GetOrdersResponse> GetOrders(GetOrdersRequest dto)
        {
            using (var connection = _connectionFactory.CreateConnectionForRead())
            {
                int offset = (dto.Page - 1) * dto.PageSize;

                const string sql = "SELECT * FROM Orders ORDER BY Id LIMIT @PageSize OFFSET @Offset";
                var orders = await connection.QueryAsync<Order>(sql, new { PageSize = dto.PageSize, Offset = offset });

                var response = new GetOrdersResponse
                {
                    Orders = orders.Select(o => new OrderDto { Id = o.Id, Customer = o.Customer, Freight = o.Freight, Country = o.Country }).ToList()
                };

                return response;
            }
        }

        public async Task SaveChanges()
        {
            //dapper no necesita hacer un SaveChanges()
        }
    }
}
