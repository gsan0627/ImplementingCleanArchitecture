using NorthWind.Sales.UseCasesPorts.CreateOrder;
using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Presenters
{
    public class CreateOrderPresenter : ICreateOrderOutputPort,
        IPresenter<CreateOrderViewModel>        
    {
        public CreateOrderViewModel Content { get; private set; }

        public Task Handle(int orderId)
        {
            Content = new CreateOrderViewModel(orderId);
            return Task.CompletedTask;
        }
    }
}