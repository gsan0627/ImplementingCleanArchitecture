using NorthWind.Sales.Entities.POCOs;
using NorthWind.Sales.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Sales.Entities.Aggregates
{
    public class OrderAggregate : Order
    {
        readonly List<OrderDetail> _orderDetailsFiled =
            new List<OrderDetail>();
        public IReadOnlyCollection<OrderDetail> OrderDetails
            => _orderDetailsFiled;

        public void AddDetail(OrderDetail orderDetail)
        {
            var existingOrderDetail =
                _orderDetailsFiled.FirstOrDefault(o => o.ProductId == orderDetail.ProductId);

            if (existingOrderDetail != null)
            {
                existingOrderDetail.Quantity += orderDetail.Quantity;
            }
            else
            {
                _orderDetailsFiled.Add(orderDetail);
            }
        }

        public void AddDetail(int productId, decimal unitPrice, short quantity)
        {
            var newOrderDetail = new OrderDetail
            {
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = quantity
            };

            AddDetail(newOrderDetail);
           
        }       
    }
}
