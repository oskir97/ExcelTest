using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.Dtos.GetOrders;
using System.ComponentModel;

namespace ExcelTest.EFC.Repositories.Queries
{
    [GraphQLDescription("Operations with Orders.")]
    public class OrdersQuery
    {
        private readonly IReadableOrdersRepository ordersReadableRepository;
        private readonly IWritableOrdersRepository ordersWritableRepository;

        public OrdersQuery(IReadableOrdersRepository ordersReadableRepository, IWritableOrdersRepository ordersWritableRepository)
        {
            this.ordersReadableRepository = ordersReadableRepository;
            this.ordersWritableRepository = ordersWritableRepository;
        }

        [GraphQLDescription("Exist Id of order in BBDD.")]
        public bool ExistOrder([GraphQLDescription("Id of order.")] int id)
        {
            try
            {
                return this.ordersReadableRepository.ExistOrder(id).Result;
            }
            catch
            {
                throw;
            }
        }

        [GraphQLDescription("Obtain orders.")]
        public List<Order> GetOrders([GraphQLDescription("Parameters of search (customerid, country, all, Page & PageSize).")] GetOrdersRequest dto)
        {
            try
            {
                return this.ordersReadableRepository.GetOrders(dto).Result.Orders.Select(o=>new Order { Id = o.Id, Customer = o.Customer, Country = o.Country, Freight = o.Freight }).ToList();
            }
            catch
            {
                throw;
            }
        }

        [GraphQLDescription("Obtain all countries of all orders.")]
        public List<string> GetCountries()
        {
            try
            {
                return this.ordersReadableRepository.GetCountries().Result.Countries;
            }
            catch
            {
                throw;
            }
        }
        
        [GraphQLDescription("Create one or multiple orders.")]
        public bool PostOrders([GraphQLDescription("List of orders to insert.")] List<Order> orders)
        {
            try
            {
                return this.ordersWritableRepository.PostOrders(orders).Result.Correct;
            }
            catch
            {
                throw;
            }
        }

        [GraphQLDescription("Update order.")]
        public bool PutOrder([GraphQLDescription("Order to update.")] Order order)
        {
            try
            {
                return this.ordersWritableRepository.PutOrder(order).Result.Correct;
            }
            catch
            {
                throw;
            }
        }

        [GraphQLDescription("Remove order.")]
        public bool RemoveOrder([GraphQLDescription("Id of order to remove.")] int id)
        {
            try
            {
                return this.ordersWritableRepository.RemoveOrder(id).Result.Correct;
            }
            catch
            {
                throw;
            }
        }
    }
}
