using NorthWind.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities.Interfaces
{
    public interface ILogWritableRepository
    {
        void Add(Log log);
        void Add(string description);
    }
}
