using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Mail
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMailService(
            this IServiceCollection services)
        {
            services.AddTransient<IMailService, MailService>();

            return services;
        }
    }
}
