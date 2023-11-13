using ExcelTest.Dtos.PutOrder;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.PutOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Controllers.PutOrder
{
    public interface IPutOrderController
    {
        ValueTask<GenericResponse<PutOrderViewModel>> PutOrder(PutOrderRequest dto);
    }
}
