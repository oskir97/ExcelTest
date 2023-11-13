using ExcelTest.Dtos.GetOrders;
using ExcelTest.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.ViewModels.GetOrders
{
    public class GetOrdersViewModel
    {
        public List<OrderViewModel> Orders { get; }

        public GetOrdersViewModel(GetOrdersResponse dto)
        {
            Orders = dto.Orders.Select(o => new OrderViewModel { Id = o.Id, Customer = o.Customer, Freight = o.Freight, Country = o.Country }).ToList();
        }
    }
}
