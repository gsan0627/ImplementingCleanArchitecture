using NorthWind.Sales.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Entities.POCOs
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public DateTime OrderDate { get; set; }
        public DiscountTypes DiscountType { get; set; } = DiscountTypes.Percentage;
        public double Discount { get; set; } = 10;
        public ShippingType ShippingType { get; set; } = ShippingType.Road;

    }
}