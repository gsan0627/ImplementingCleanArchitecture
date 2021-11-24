using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Console.Views
{
    public class CreateOrderConsoleView
    {
        readonly CreateOrderViewModel _model;
        public CreateOrderConsoleView(CreateOrderViewModel model)
        {
            _model = model;
        }

        public void ExecuteResult()
        {
            System.Console.WriteLine($"Se ha creado la orden {_model.OrderId}");
        }

    }
}
