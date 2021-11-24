using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.UseCasesPorts.CreateOrder;
using System;

namespace NorthWind.Sales.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderOutputPort,
                CreateOrderPresenter>();

            return services;
        }
    }
}
