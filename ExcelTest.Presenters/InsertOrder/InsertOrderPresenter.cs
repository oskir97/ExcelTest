using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.InsertOrder;
using ExcelTest.UseCasesPorts.InsertOrder;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.InsertOrder;

namespace ExcelTest.Presenters.InsertOrder
{
    public class InsertOrderPresenter : IInsertOrderOutputPort, IPresenter<GenericResponse<InsertOrderViewModel>>
    {
        public GenericResponse<InsertOrderViewModel> Content { get; private set; } = null!;

        public async Task Handle(InsertOrderResponse dto)
        {
            Content = new GenericResponse<InsertOrderViewModel>(new InsertOrderViewModel(dto));
        }
    }
}
