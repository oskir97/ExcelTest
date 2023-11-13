using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.RemoveOrder;
using ExcelTest.UseCasesPorts.RemoveOrder;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.RemoveOrder;

namespace ExcelTest.Presenters.RemoveOrder
{
    public class RemoveOrderPresenter : IRemoveOrderOutputPort, IPresenter<GenericResponse<RemoveOrderViewModel>>
    {
        public GenericResponse<RemoveOrderViewModel> Content { get; private set; } = null!;

        public async Task Handle(RemoveOrderResponse dto)
        {
            Content = new GenericResponse<RemoveOrderViewModel>(new RemoveOrderViewModel(dto));
        }
    }
}
