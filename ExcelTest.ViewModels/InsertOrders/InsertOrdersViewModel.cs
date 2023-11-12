using ExcelTest.Dtos.InsertOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.ViewModels.InsertOrders
{
    public class InsertOrdersViewModel
    {

        public bool Correct { get; }

        public InsertOrdersViewModel(InsertOrdersResponse dto)
        {
            Correct = dto.Correct;
        }

    }
}
