using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NorthWind.Entities;
using NorthWind.Sales.Controllers;
using NorthWind.Sales.Events;
using NorthWind.Sales.Loggers;
using NorthWind.Sales.Mail;
using NorthWind.Sales.Presenters;
using NorthWind.Sales.Repositories.IoC;
using NorthWind.Sales.UseCases;
using NorthWind.Sales.WebExceptionPresenters.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Sales.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(Filters.Register);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NorthWind.Sales.WebApi", Version = "v1" });
            });

            services.AddEntityServices()
               .AddLogger()
               .AddEventHandlers()
               .AddMailService()
               .AddPresenters()
               .AddRepositories(Configuration, "NorthWindSales")
               .AddControllerService();
            //ICreateOrderController
            services.AddUseCasesServices();

            services.AddCors(options => { 
                options.AddPolicy("default", config => {
                    config.AllowAnyMethod();
                    config.AllowAnyHeader();
                    config.AllowAnyOrigin();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NorthWind.Sales.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("default");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
