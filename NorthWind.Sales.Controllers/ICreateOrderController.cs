using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Controllers
{
    public interface ICreateOrderController
    {
        Task<CreateOrderViewModel> CreateOrder(CreateOrderDTO order); 
    }
}
