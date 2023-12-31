﻿using Dapper;
using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.Dtos.Common;
using ExcelTest.Dtos.GetCountries;
using ExcelTest.Dtos.GetOrders;
using ExcelTest.EFC.DataContexts.DbConnection;
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

        public async ValueTask<bool> ExistOrder(int id)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnectionForRead())
                {
                    const string sql = "SELECT COUNT(*) FROM Orders WHERE Id = @Id";
                    var count = await connection.QuerySingleAsync<int>(sql, new { id });
                    return count > 0;
                }
            }
            catch
            {
                throw;
            }
        }

        public async ValueTask<GetOrdersResponse> GetOrders(GetOrdersRequest dto)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnectionForRead())
                {
                    int offset = (dto.Page - 1) * dto.PageSize;

                    string sql;
                    object parameters;

                    if (!string.IsNullOrEmpty(dto.customerid) && !string.IsNullOrEmpty(dto.country))
                    {
                        string all = dto.all.HasValue && dto.all.Value ? "AND" : "OR";
                        sql = $"SELECT * FROM Orders WHERE Customer LIKE CONCAT('%', @Customer, '%') {all} Country LIKE CONCAT('%', @Country, '%') ORDER BY Id LIMIT @PageSize OFFSET @Offset";
                        parameters = new { Customer = dto.customerid, Country = dto.country, PageSize = dto.PageSize, Offset = offset };
                    }
                    else
                    {
                        sql = $"SELECT * FROM Orders WHERE (@CustomerId IS NULL OR Customer LIKE CONCAT('%', @CustomerId, '%')) AND (@Country IS NULL OR Country LIKE CONCAT('%', @Country, '%')) ORDER BY Id LIMIT @PageSize OFFSET @Offset";
                        parameters = new { CustomerId = dto.customerid, Country = dto.country, PageSize = dto.PageSize, Offset = offset };
                    }

                    var orders = await connection.QueryAsync<Order>(sql, parameters);

                    var response = new GetOrdersResponse
                    {
                        Orders = orders.Select(o => new OrderDto { Id = o.Id, Customer = o.Customer, Freight = o.Freight, Country = o.Country }).ToList()
                    };

                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async ValueTask<GetCountriesResponse> GetCountries()
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnectionForRead())
                {
                    const string sql = "SELECT DISTINCT Country FROM Orders ORDER BY Country";
                    var countries = await connection.QueryAsync<string>(sql);

                    var response = new GetCountriesResponse
                    {
                        Countries = countries.ToList()
                    };

                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task SaveChanges()
        {
            //dapper no necesita hacer un SaveChanges()
        }
    }
}
