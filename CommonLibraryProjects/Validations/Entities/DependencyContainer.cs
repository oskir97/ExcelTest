using CommonLibraryProjects.Validations.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Validations.Entities
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddValidationService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IValidationService<>), typeof(ValidationService<>));
            return services;
        }
    }
}
