using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOs;
using NorthWind.Sales.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.EFCore.Repositories
{
    public class LogWritableRepository : ILogWritableRepository
    {
        readonly NorthWindSalesContext _context;
        public LogWritableRepository(NorthWindSalesContext context)
            => (_context) = (context);

        public void Add(Log log)
        => _context.Logs.Add(log);

        public void Add(string description)
        => _context.Logs.Add(new Log(description));

    }
}
