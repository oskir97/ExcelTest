using ExcelTest.Dtos.InsertOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.InsertOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Controllers.InsertOrders
{
    public interface IInsertOrdersController
    {
        ValueTask<GenericResponse<InsertOrdersViewModel>> InsertOrders(InsertOrdersRequest dto);
    }
}
