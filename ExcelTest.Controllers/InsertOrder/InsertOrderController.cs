using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.InsertOrder;
using ExcelTest.UseCasesPorts.InsertOrder;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.InsertOrder;

namespace ExcelTest.Controllers.InsertOrder
{
    public class InsertOrderController : IInsertOrderController
    {
        private readonly IInsertOrderInputPort inputPort;
        private readonly IInsertOrderOutputPort outputPort;

        public InsertOrderController(IInsertOrderInputPort inputPort, IInsertOrderOutputPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        public async ValueTask<GenericResponse<InsertOrderViewModel>> InsertOrder(InsertOrderRequest dto)
        {
            await inputPort.Handle(dto);
            return ((IPresenter<GenericResponse<InsertOrderViewModel>>)outputPort).Content;
        }
    }
}
