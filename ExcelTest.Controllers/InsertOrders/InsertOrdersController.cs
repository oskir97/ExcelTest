using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.InsertOrders;
using ExcelTest.UseCasesPorts.InsertOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.InsertOrders;

namespace ExcelTest.Controllers.InsertOrders
{
    public class InsertOrdersController : IInsertOrdersController
    {
        private readonly IInsertOrdersInputPort inputPort;
        private readonly IInsertOrdersOutputPort outputPort;

        public InsertOrdersController(IInsertOrdersInputPort inputPort, IInsertOrdersOutputPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        public async ValueTask<GenericResponse<InsertOrdersViewModel>> InsertOrders(InsertOrdersRequest dto)
        {
            await inputPort.Handle(dto);
            return ((IPresenter<GenericResponse<InsertOrdersViewModel>>)outputPort).Content;
        }
    }
}
