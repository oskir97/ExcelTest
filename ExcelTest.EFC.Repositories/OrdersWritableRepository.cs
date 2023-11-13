using ExcelTest.Common.Interfaces;
using ExcelTest.Dtos.PostOrders;
using ExcelTest.Core.Entities;
using System.Data;
using Dapper;
using ExcelTest.EFC.Repositories.DbConnection;
using ExcelTest.Dtos.PutOrder;
using ExcelTest.Dtos.RemoveOrder;
using ExcelTest.Dtos.GetOrders;
using Org.BouncyCastle.Asn1.X509;

namespace ExcelTest.EFC.Repositories
{
    public class OrdersWritableRepository : IWritableOrdersRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public OrdersWritableRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<PostOrdersResponse> PostOrders(List<Order> orders)
        {
            var result = new PostOrdersResponse
            {
                Correct = true
            };

            const string sql = "INSERT INTO Orders (Id, Customer, Freight, Country) VALUES (@Id, @Customer, @Freight, @Country)";

            using (var connection = _connectionFactory.CreateConnectionForWrite())
            {

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(sql, orders, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        result.Correct = false;
                    }
                }
            }

            return result;
        }

        public async Task<PutOrderResponse> PutOrder(Order order)
        {
            var result = new PutOrderResponse
            {
                Correct = true
            };

            const string sql = "UPDATE Orders SET Customer = @Customer, Freight = @Freight, Country = @Country WHERE Id = @Id";

            using (var connection = _connectionFactory.CreateConnectionForWrite())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(sql, order, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        result.Correct = false;
                    }
                }
            }

            return result;
        }

        public async Task<RemoveOrderResponse> RemoveOrder(int id)
        {
            var response = new RemoveOrderResponse
            {
                Correct = true
            };

            const string sql = "DELETE FROM Orders WHERE Id = @Id";

            using (var connection = _connectionFactory.CreateConnectionForWrite())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(sql, new { Id = id }, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        response.Correct = false;
                    }
                }
            }

            return response;
        }

        public async Task SaveChanges()
        {
            //dapper no necesita hacer un SaveChanges()
        }
    }
}
