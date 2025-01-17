﻿using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Events
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEventHandlers(
            this IServiceCollection services)
        {
            services.AddScoped<IEventHandler<SpecialOrderCreatedEvent>,
                SpecialOrderCreatedEventHandler>();

            return services;
        }
    }
}