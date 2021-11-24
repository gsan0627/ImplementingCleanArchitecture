using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.EFCore.DataContext
{
    public class NorthWindSalesContextFactory
        : IDesignTimeDbContextFactory<NorthWindSalesContext>
    {
        public NorthWindSalesContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<NorthWindSalesContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=NorthWindSales");
            return new NorthWindSalesContext(optionsBuilder.Options);
        }
    }
}