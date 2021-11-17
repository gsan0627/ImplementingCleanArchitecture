using NorthWind.Entities.Events;
using NorthWind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Events
{
    public class SpecialOrderCreatedEventHandler
        : IEventHandler<SpecialOrderCreatedEvent>
    {
        readonly IMailService _service;

        SpecialOrderCreatedEventHandler(IMailService mailService)
            => _service = mailService;

        public ValueTask Handle(SpecialOrderCreatedEvent orderCreated)
        {
            return _service.Send($"Order {orderCreated.OrderId} con {orderCreated.ProductsCount}");
        }
    }
}
