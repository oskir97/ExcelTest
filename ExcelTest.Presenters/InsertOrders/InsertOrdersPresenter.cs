using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.InsertOrders;
using ExcelTest.UseCasesPorts.InsertOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.InsertOrders;

namespace ExcelTest.Presenters.InsertOrders
{
    public class InsertOrdersPresenter : IInsertOrdersOutputPort, IPresenter<GenericResponse<InsertOrdersViewModel>>
    {
        public GenericResponse<InsertOrdersViewModel> Content { get; private set; } = null!;

        public async Task Handle(InsertOrdersResponse dto)
        {
            Content = new GenericResponse<InsertOrdersViewModel>(new InsertOrdersViewModel(dto));
        }
    }
}
