using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Sales.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly NorthWindSalesContext _context;
        readonly IApplicationStatusLogger _logger;
        public UnitOfWork(NorthWindSalesContext context,
            IApplicationStatusLogger logger)
            => (_context, _logger) = (context, logger);

        public async ValueTask<int> SaveChanges()
        {
            int result;
            try
            {
                result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.Log(ex.InnerException?.Message ?? ex.Message);
                throw new UpdateException(
                    ex.InnerException?.Message ?? ex.Message,
                    ex.Entries.Select(e => e.Entity.GetType().Name)
                    .ToList());
            }                 
            catch(Exception ex)
            {
                _logger.Log(ex.Message);
                throw new GeneralException("Error al persistir los cambios",ex.Message);
            }

            return result;
            
        }

    }
}
