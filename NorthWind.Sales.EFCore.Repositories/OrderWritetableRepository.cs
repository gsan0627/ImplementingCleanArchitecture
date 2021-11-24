using NorthWind.Sales.EFCore.DataContext;
using NorthWind.Sales.Entities.Aggregates;
using NorthWind.Sales.UseCases.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.EFCore.Repositories
{
    public class OrderWritetableRepository : IOrderWritableRepository
    {
        readonly NorthWindSalesContext _context;
        public OrderWritetableRepository(NorthWindSalesContext context)
        => (_context) = (context);

        public void CreateOrder(OrderAggregate order)
        {
            _context.Add(order);
            foreach (var detail in order.OrderDetails)
            {
                _context.Add(new OrderDetailt
                {
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                    UnitPrice = detail.UnitPrice,
                    Order = order
                });
            }
        }
    }
}
