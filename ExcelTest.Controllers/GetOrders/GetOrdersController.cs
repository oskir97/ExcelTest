using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.GetOrders;
using ExcelTest.UseCasesPorts.GetOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.GetOrders;
using ExcelTest.ViewModels.PostOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Controllers.GetOrders
{
    public class GetOrdersController : IGetOrdersController
    {
        private readonly IGetOrdersInputPort inputPort;
        private readonly IGetOrdersOutputPort outputPort;

        public GetOrdersController(IGetOrdersInputPort inputPort, IGetOrdersOutputPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        public async ValueTask<GenericResponse<GetOrdersViewModel>> GetOrders(GetOrdersRequest dto)
        {
            await inputPort.Handle(dto);
            return ((IPresenter<GenericResponse<GetOrdersViewModel>>)outputPort).Content;
        }
    }
}
