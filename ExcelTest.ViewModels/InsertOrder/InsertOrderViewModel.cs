using ExcelTest.Dtos.InsertOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.ViewModels.InsertOrder
{
    public class InsertOrderViewModel
    {

        public int Id { get; }

        public InsertOrderViewModel(InsertOrderResponse dto)
        {
            Id = dto.Id;
        }

    }
}
