using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Loggers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLogger(
            this IServiceCollection services)
        {
            services.AddScoped<IApplicationStatusLogger, DebugStatusLogger>();

            return services;
        }
    }
}
