using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.GetOrders;
using ExcelTest.UseCasesPorts.GetOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.GetOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Presenters.GetOrders
{
    public class GetOrdersPresenter : IGetOrdersOutputPort, IPresenter<GenericResponse<GetOrdersViewModel>>
    {
        public GenericResponse<GetOrdersViewModel> Content { get; private set; } = null!;

        public async Task Handle(GetOrdersResponse dto)
        {
            Content = new GenericResponse<GetOrdersViewModel>(new GetOrdersViewModel(dto));
        }
    }
}
