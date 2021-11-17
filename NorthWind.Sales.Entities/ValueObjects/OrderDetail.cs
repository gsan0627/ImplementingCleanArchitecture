using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Entities.ValueObjects
{
    public class OrderDetail
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
