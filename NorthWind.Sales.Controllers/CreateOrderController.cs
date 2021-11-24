using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.Presenters;
using NorthWind.Sales.UseCasesPorts.CreateOrder;
using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Controllers
{
    public class CreateOrderController : ICreateOrderController
    {
        readonly ICreateOrderInputPort _inputPort;
        readonly ICreateOrderOutputPort _outputPort;
       
        public CreateOrderController(ICreateOrderInputPort inputPort,
            ICreateOrderOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        public async Task<CreateOrderViewModel> CreateOrder(CreateOrderDTO order)
        {
            await _inputPort.Handle(order);
            return ((IPresenter<CreateOrderViewModel>)_outputPort).Content;
        }
    }
}
