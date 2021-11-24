using NorthWind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NorthWind.Sales.Loggers
{
    public class DebugStatusLogger : IApplicationStatusLogger
    {
        public void Log(string message)
        {
            Debug.WriteLine($"*** DSL: {message}");
        }
    }
}
