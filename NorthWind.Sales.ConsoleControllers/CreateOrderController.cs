using NorthWind.Sales.Console.Views;
using NorthWind.Sales.Controllers;
using NorthWind.Sales.DTOs.CreateOrder;
using System;
using System.Threading.Tasks;

namespace NorthWind.Sales.ConsoleControllers
{
    public class CreateOrderController
    {
        readonly ICreateOrderController _controller;
        public CreateOrderController(ICreateOrderController controller)
        {
            _controller = controller;
        }

        public async Task<CreateOrderConsoleView> CreateOrder(CreateOrderDTO order)
        {
            var model = await _controller.CreateOrder(order);
            return new CreateOrderConsoleView(model);
        }
    }
}
