using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.PostOrders;
using ExcelTest.UseCasesPorts.PostOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.PostOrders;

namespace ExcelTest.Presenters.PostOrders
{
    public class PostOrdersPresenter : IPostOrdersOutputPort, IPresenter<GenericResponse<PostOrdersViewModel>>
    {
        public GenericResponse<PostOrdersViewModel> Content { get; private set; } = null!;

        public async Task Handle(PostOrdersResponse dto)
        {
            Content = new GenericResponse<PostOrdersViewModel>(new PostOrdersViewModel(dto));
        }
    }
}
