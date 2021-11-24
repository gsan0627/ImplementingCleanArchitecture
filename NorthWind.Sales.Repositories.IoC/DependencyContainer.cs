using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces;
using NorthWind.Sales.EFCore.DataContext;
using NorthWind.Sales.EFCore.Repositories;
using NorthWind.Sales.UseCases.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Repositories.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services, 
            IConfiguration configuration,
            string connectionStringName)
        {
            services.AddDbContext<NorthWindSalesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(connectionStringName)));

            services.AddScoped<IOrderWritableRepository,
                OrderWritetableRepository>();

            services.AddScoped<ILogWritableRepository,
                LogWritableRepository>();

            services.AddScoped<IUnitOfWork,
                UnitOfWork>();

            return services;
        }
    }
}
