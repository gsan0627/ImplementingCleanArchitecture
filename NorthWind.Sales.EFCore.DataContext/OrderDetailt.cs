using NorthWind.Sales.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.EFCore.DataContext
{
    public class OrderDetailt: Entities.ValueObjects.OrderDetail
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
