using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.DTOs.CreateOrder
{
    public class CreateOrderDetailDTO
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
