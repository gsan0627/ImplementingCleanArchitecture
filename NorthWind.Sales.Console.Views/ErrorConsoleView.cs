using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Console.Views
{
    public class ErrorConsoleView
    {
        readonly Exception _model;
        public ErrorConsoleView(Exception model)
        {
            _model = model;
        }

        public void ExecuteResult()
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"Error: {_model.Message}");
            System.Console.ResetColor();
        }
    }
}
