using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities.Interfaces
{
    public interface IApplicationStatusLogger
    {
        void Log(string message);
    }
}
