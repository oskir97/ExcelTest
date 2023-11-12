using ExcelTest.Dtos.InsertOrder;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.InsertOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Controllers.InsertOrder
{
    public interface IInsertOrderController
    {
        ValueTask<GenericResponse<InsertOrderViewModel>> InsertOrder(InsertOrderRequest dto);
    }
}
