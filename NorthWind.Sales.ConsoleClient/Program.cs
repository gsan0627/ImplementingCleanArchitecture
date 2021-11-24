using NorthWind.Entities;
using NorthWind.Sales.Console.Views;
using NorthWind.Sales.Controllers;
using NorthWind.Sales.Events;
using System;
using System.Collections.Generic;
using System.Text;
using NorthWind.Sales.Mail;
using NorthWind.Sales.Presenters;
using NorthWind.Sales.Loggers;
using NorthWind.Sales.Repositories.IoC;
using NorthWind.Sales.UseCases;

namespace NorthWind.Sales.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceContainer.ConfigureServices(services => {
                services.AddEntityServices()
              .AddLogger()
              .AddEventHandlers()
              .AddMailService()
              .AddPresenters()
              .AddRepositories(ServiceContainer.Configuration, "NorthWindSales")
              .AddControllerService()
              .AddUseCasesServices();
            });

            CreateOrder();
        }

        static void CreateOrder()
        {
            var controller =
                new NorthWind.Sales.ConsoleControllers.CreateOrderController(
                    ServiceContainer.GetService<ICreateOrderController>());

            try
            {
                var order = new DTOs.CreateOrder.CreateOrderDTO
                {
                    CustomerId = "JENNA",
                    ShipAddress = "5 sur 907",
                    ShipCity = "Puebla",
                    ShipCountry = "Mexico",
                    ShipPostalCode = "72500",
                    OrderDetails = new List<DTOs.CreateOrder.CreateOrderDetailDTO>
                    {
                        new DTOs.CreateOrder.CreateOrderDetailDTO
                        { ProductId=1, Quantity=1, UnitPrice=20 }
                    }
                };
                var view = controller.CreateOrder(order).Result;
                view.ExecuteResult();

            }
            catch (Exception ex)
            {
                new ErrorConsoleView(ex?.InnerException ?? ex).ExecuteResult();
            }
        }

    }
}
