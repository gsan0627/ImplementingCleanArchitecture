using FluentValidation;
using NorthWind.Entities.Events;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.Validators;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.Entities.Aggregates;
using NorthWind.Sales.Events;
using NorthWind.Sales.UseCases.Common.Interfaces;
using NorthWind.Sales.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class CreateOrderInteractor
        : ICreateOrderInputPort
    {
        readonly IOrderWritableRepository _orderRepository;
        readonly ILogWritableRepository _logRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly ICreateOrderOutputPort _outputPort;
        readonly IApplicationStatusLogger _logger;
        readonly IEnumerable<NorthWind.Entities.Validators.IValidator<CreateOrderDTO>> _Validators;
        readonly IEventHub<SpecialOrderCreatedEvent> _eventHub;
        readonly IValidatorService<CreateOrderDTO> _validatorService;

        public CreateOrderInteractor(
            IOrderWritableRepository orderRepository,
            ILogWritableRepository logRepository,
            IUnitOfWork unitOfWork,
            IApplicationStatusLogger logger,
            IEnumerable<NorthWind.Entities.Validators.IValidator<CreateOrderDTO>> validators,
            IEventHub<SpecialOrderCreatedEvent> eventHub,
            IValidatorService<CreateOrderDTO> validatorService,
            ICreateOrderOutputPort outputPort)
        => (_orderRepository, _logRepository, _unitOfWork, _logger, _Validators, _eventHub, _validatorService, _outputPort)
            = (orderRepository, logRepository, unitOfWork, logger, validators, eventHub, validatorService, outputPort);

        public async Task Handle(CreateOrderDTO order)
        {
            _validatorService.Validate(order, _Validators, _logger);

            OrderAggregate orderAggregate = new OrderAggregate
            {
                CustomerId = order.CustomerId,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode
            };

            foreach (var item in order.OrderDetails)
            {
                orderAggregate.AddDetail(item.ProductId, item.UnitPrice, item.Quantity);
            }

            _orderRepository.CreateOrder(orderAggregate);
            _logRepository.Add("Crear orden de compras");
            await _unitOfWork.SaveChanges();

            if (orderAggregate.OrderDetails.Count > 3)
            {
                await _eventHub.Raise(
                    new SpecialOrderCreatedEvent(orderAggregate.Id,
                    orderAggregate.OrderDetails.Count));
            }

            await _outputPort.Handle(orderAggregate.Id);
        }
    }
}
