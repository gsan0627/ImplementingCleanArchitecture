﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.DTOs.CreateOrder
{
    public class CreateOrderDTO
    {
        public string CustomerId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public List<CreateOrderDetailDTO> OrderDetails { get; set; }

    }
}
