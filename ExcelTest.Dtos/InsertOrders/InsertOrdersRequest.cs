﻿using ExcelTest.Dtos.Common;

namespace ExcelTest.Dtos.InsertOrders
{
    public class InsertOrdersRequest
    {
        public required List<OrderDto> Orders { get; set; }
    }
}
