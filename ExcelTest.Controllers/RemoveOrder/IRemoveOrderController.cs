using ExcelTest.Dtos.PutOrder;
using ExcelTest.Dtos.RemoveOrder;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.PutOrder;
using ExcelTest.ViewModels.RemoveOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Controllers.RemoveOrder
{
    public interface IRemoveOrderController
    {
        ValueTask<GenericResponse<RemoveOrderViewModel>> RemoveOrder(RemoveOrderRequest dto);
    }
}
