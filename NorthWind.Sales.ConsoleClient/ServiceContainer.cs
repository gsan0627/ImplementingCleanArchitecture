

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace NorthWind.Sales.ConsoleClient
{
    public static class ServiceContainer
    {
        static IServiceProvider ServiceProvider;
        public static void ConfigureServices(
            Action<IServiceCollection> configureServices)
        {
            IServiceCollection services = new ServiceCollection();
            configureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() =>
            ServiceProvider.GetService<T>();

        public static IConfiguration Configuration =>
            new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
