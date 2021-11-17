using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Events;
using NorthWind.Entities.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEntityServices(
            this IServiceCollection services)
        {
            services.AddScoped(typeof(IEventHub<>), 
                typeof(EventHub<>));
            services.AddSingleton(typeof(IValidatorService<>), 
                typeof(ValidatorService<>));
            return services;
        }
    }
}
