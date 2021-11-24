using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddControllerService(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderController,
                CreateOrderController>();

            return services;
        }
    }
}
