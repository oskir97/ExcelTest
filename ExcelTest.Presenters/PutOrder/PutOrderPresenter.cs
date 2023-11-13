using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.PutOrder;
using ExcelTest.UseCasesPorts.PutOrder;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.PutOrder;

namespace ExcelTest.Presenters.PutOrder
{
    public class PutOrderPresenter : IPutOrderOutputPort, IPresenter<GenericResponse<PutOrderViewModel>>
    {
        public GenericResponse<PutOrderViewModel> Content { get; private set; } = null!;

        public async Task Handle(PutOrderResponse dto)
        {
            Content = new GenericResponse<PutOrderViewModel>(new PutOrderViewModel(dto));
        }
    }
}
