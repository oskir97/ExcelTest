﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Dtos.PutOrder
{
    public class PutOrderRequest
    {
        public int Id { get; set; }
        public required string Customer { get; set; }
        public decimal Freight { get; set; }
        public required string Country { get; set; }
    }
}
