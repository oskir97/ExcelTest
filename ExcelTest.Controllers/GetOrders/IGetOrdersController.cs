using ExcelTest.Dtos.GetOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.GetOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Controllers.GetOrders
{
    public interface IGetOrdersController
    {
        ValueTask<GenericResponse<GetOrdersViewModel>> GetOrders(GetOrdersRequest dto);
    }
}
