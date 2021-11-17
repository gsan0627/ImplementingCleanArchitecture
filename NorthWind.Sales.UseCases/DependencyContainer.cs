using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Validators;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.UseCases.CreateOrder;
using NorthWind.Sales.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
            this IServiceCollection services)
        {
            services.AddTransient<ICreateOrderInputPort,
                CreateOrderInteractor>();
            return services;
        }
    }
}
