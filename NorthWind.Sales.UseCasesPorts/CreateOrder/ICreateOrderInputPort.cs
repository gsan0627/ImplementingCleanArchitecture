using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.UseCasesPorts.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderInputPort
        : IPorts<CreateOrderDTO>
    {
    }
}
