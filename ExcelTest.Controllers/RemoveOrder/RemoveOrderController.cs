using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.PutOrder;
using ExcelTest.Dtos.RemoveOrder;
using ExcelTest.UseCasesPorts.PutOrder;
using ExcelTest.UseCasesPorts.RemoveOrder;
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
    public class RemoveOrderController : IRemoveOrderController
    {
        private readonly IRemoveOrderInputPort inputPort;
        private readonly IRemoveOrderOutputPort outputPort;

        public RemoveOrderController(IRemoveOrderInputPort inputPort, IRemoveOrderOutputPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        public async ValueTask<GenericResponse<RemoveOrderViewModel>> RemoveOrder(RemoveOrderRequest dto)
        {
            await inputPort.Handle(dto);
            return ((IPresenter<GenericResponse<RemoveOrderViewModel>>)outputPort).Content;
        }
    }
}
