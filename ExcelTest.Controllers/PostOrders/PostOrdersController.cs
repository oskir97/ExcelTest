using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.PostOrders;
using ExcelTest.UseCasesPorts.PostOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.PostOrders;

namespace ExcelTest.Controllers.PostOrders
{
    public class PostOrdersController : IPostOrdersController
    {
        private readonly IPostOrdersInputPort inputPort;
        private readonly IPostOrdersOutputPort outputPort;

        public PostOrdersController(IPostOrdersInputPort inputPort, IPostOrdersOutputPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        public async ValueTask<GenericResponse<PostOrdersViewModel>> PostOrders(PostOrdersRequest dto)
        {
            await inputPort.Handle(dto);
            return ((IPresenter<GenericResponse<PostOrdersViewModel>>)outputPort).Content;
        }
    }
}
