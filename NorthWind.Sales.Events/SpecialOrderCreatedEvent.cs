using NorthWind.Entities.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Events
{
    public class SpecialOrderCreatedEvent : IEvent
    {
        public int OrderId { get; }
        public int ProductsCount { get; }
        public SpecialOrderCreatedEvent(int orderId, int productsCount)
            => (OrderId, ProductsCount) = (orderId, productsCount);
    }
}
