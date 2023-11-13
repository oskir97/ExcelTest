using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.PostOrders;
using ExcelTest.Dtos.PutOrder;
using ExcelTest.UseCasesPorts.PostOrders;
using ExcelTest.UseCasesPorts.PutOrder;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.PostOrders;
using ExcelTest.ViewModels.PutOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Controllers.PutOrder
{
    public class PutOrderController : IPutOrderController
    {
        private readonly IPutOrderInputPort inputPort;
        private readonly IPutOrderOutputPort outputPort;

        public PutOrderController(IPutOrderInputPort inputPort, IPutOrderOutputPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        public async ValueTask<GenericResponse<PutOrderViewModel>> PutOrder(PutOrderRequest dto)
        {
            await inputPort.Handle(dto);
            return ((IPresenter<GenericResponse<PutOrderViewModel>>)outputPort).Content;
        }
    }
}
