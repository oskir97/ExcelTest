using ExcelTest.Common.Interfaces;
using ExcelTest.Dtos.InsertOrder;
using ExcelTest.Core.Entities;
using System.Data;
using Dapper;

namespace ExcelTest.EFC.Repositories
{
    public class OrderWritableRepository : IWritableOrderRepository
    {
        private readonly IDbConnection connection;

        public OrderWritableRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<InsertOrderResponse> InsertOrder(Order order)
        {
            var result = new InsertOrderResponse
            {
                Id = order.Id
            };

            const string sql = "INSERT INTO Orders (Id, Customer, Freight, Country) VALUES (@Id, @Customer, @Freight, @Country)";
            await connection.ExecuteAsync(sql, order);

            return result;
        }

        public async Task SaveChanges()
        {
            //dapper no necesita hacer un SaveChanges()
        }
    }
}
