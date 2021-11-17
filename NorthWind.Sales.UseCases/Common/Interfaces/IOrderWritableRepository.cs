using NorthWind.Sales.Entities.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.UseCases.Common.Interfaces
{
    public interface IOrderWritableRepository
    {
        void CreateOrder(OrderAggregate order);
    }
}
