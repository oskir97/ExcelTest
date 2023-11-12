﻿using ExcelTest.Controllers.InsertOrder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationControllers(this IServiceCollection services)
        {
            services.AddScoped<IInsertOrderController, InsertOrderController>();
            return services;
        }
    }
}